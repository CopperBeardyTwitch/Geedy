using System.Threading.Tasks;
using Geed.Models;

namespace Geed.Interfaces
{
    public interface IWebAPIService
    {
        Task<CurrentUserPublicProfile> GetUserProfileAsync(string id, string token);
    }
}