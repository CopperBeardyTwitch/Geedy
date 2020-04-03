using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeedService.DataEntities;
using GeedService.Models;


namespace GeedService.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(string id);
        Task<User> GetUserByUserName(string username);
        Task<List<User>> GetUsers(string username);
        void NewUser(CurrentUserPublicProfile user);

        void EditUser(CurrentUserPublicProfile userprofile);

        void RemoveUser(string id);
    }
}
