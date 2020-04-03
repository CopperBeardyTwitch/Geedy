using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Geed.Interfaces;
using Geed.Services;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(IdentityService))]
namespace Geed.Services
{
    public class IdentityService : IIdentityService
    {
        public static string Tenant = "geedTenant.onmicrosoft.com";
        public static string ClientId = "f8ca5a9b-5628-4a87-b715-ff0d56b0f8c4";
        public static string SignUpAndInPolicy = "B2C_1_SignInUp";

        public static string AuthorityBase = $"https://login.microsoftonline.com/tfp/{Tenant}/";
        public static string Authority = $"{AuthorityBase}{SignUpAndInPolicy}";

        private static readonly string RedirectUrl = $"msal{ClientId}://auth";
        public static string[] Scopes = new string[] { "https://geedTenant.onmicrosoft.com/service/gr.read.only" };

        public static PublicClientApplication AuthClient = null;

        public UIParent UIParent { get; set; }

        public IdentityService()
        {
            AuthClient = new PublicClientApplication(ClientId)
            {
                ValidateAuthority = false,
                RedirectUri = RedirectUrl
            };
        }

       

        public async Task<AuthenticationResult> Login()
        {
            AuthenticationResult msalResult = null;
            // Running on Android - we need UIParent to be set to the main Activity
            if (UIParent == null && Device.RuntimePlatform == Device.Android)
                return msalResult;

            // First check if the token happens to be cached - grab silently
           msalResult = await GetCachedSignInTokenAsync();

            if (msalResult != null)
                return msalResult;

            // Token not in cache - call adb2c to acquire it
            try
            {
                msalResult = await AuthClient.AcquireTokenAsync(Scopes,
                    GetUserByPolicy(AuthClient.Users,SignUpAndInPolicy),
                    UIBehavior.ForceLogin,null,null,Authority,UIParent);
                
            }
            catch (MsalServiceException ex)
            {
                switch (ex.ErrorCode)
                {
                    case MsalClientException.AuthenticationCanceledError:
                        System.Diagnostics.Debug.WriteLine("User cancelled");
                        break;
                    case "access_denied":
                        // most likely the forgot password was hit
                        System.Diagnostics.Debug.WriteLine("Forgot password");
                        break;
                    default:
                        System.Diagnostics.Debug.WriteLine(ex);
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            return msalResult;
        }

        public async Task<AuthenticationResult> GetCachedSignInTokenAsync()
        {
            try
            {
                // This checks to see if there's already a user in the cache
                var authResult = await AuthClient.AcquireTokenSilentAsync(Scopes,
                    GetUserByPolicy(AuthClient.Users,SignUpAndInPolicy),
                    Authority,false);
                return authResult;
            }
            catch (MsalUiRequiredException ex)
            {
                // happens if the user hasn't logged in yet & isn't in the cache
                System.Diagnostics.Debug.WriteLine(ex);
            }

            return null;
        }

        public void Logout()
        {
            foreach (var user in AuthClient.Users)
            {
                AuthClient.Remove(user);
            }
        }

        private IUser GetUserByPolicy(IEnumerable<IUser> users, string policy)
        {
            return (from user in users let userIdentifier = Base64UrlDecode(user.Identifier.Split('.')[0])
                where userIdentifier.EndsWith(policy.ToLower(), StringComparison.OrdinalIgnoreCase)
                select user).FirstOrDefault();
        }


        private static string Base64UrlDecode(string s)
        {
            s = s.Replace('-', '+').Replace('_', '/');
            s = s.PadRight(s.Length + (4 - s.Length % 4) % 4, '=');
            var byteArray = Convert.FromBase64String(s);
            var decoded = Encoding.UTF8.GetString(byteArray, 0, byteArray.Count());
            return decoded;
        }

        private JObject ParseIdToken(string idToken)
        {
            // Get the piece with actual user info
            idToken = idToken.Split('.')[1];
            idToken = Base64UrlDecode(idToken);
            return JObject.Parse(idToken);
        }
    }
}
