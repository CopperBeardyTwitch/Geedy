using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Geed.Interfaces
{
    public interface IIdentityService
    {
     Task<AuthenticationResult> Login();
        Task<AuthenticationResult> GetCachedSignInTokenAsync();
        void Logout();
        UIParent UIParent { get; set; }
    }
}
