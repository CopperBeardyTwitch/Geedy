using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Geed.Interfaces;
using Geed.Models;
using Newtonsoft.Json;


namespace Geed.Services
{
    public class WebAPIService : IWebAPIService
    {
        readonly HttpClient webClient = new HttpClient();

        public async Task<CurrentUserPublicProfile> GetUserProfileAsync(string id ,string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{APIKeys.WebApiUrl}/api/user/UserProfile/{id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await webClient.SendAsync(request);

            var userjson = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CurrentUserPublicProfile>(userjson);
        }
    }
}
