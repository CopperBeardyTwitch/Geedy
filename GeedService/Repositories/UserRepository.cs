using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeedService.DataAccess;
using GeedService.DataEntities;
using GeedService.Interfaces;
using GeedService.Model;
using GeedService.Models;
using Microsoft.EntityFrameworkCore;



namespace GeedService.Repositories
{
    public class UserRepository : IUserRepository
    {
        //Todo implement user repository
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById( string id)
        {
            var result = await _context.UserProfiles.SingleOrDefaultAsync(u => u.UserId == id);
            return new User
            {
                Username = result.Username,
                Bio = result.Bio,
                FacebookId = result.FacebookId,
                InstagramId = result.InstagramId,
                LinkedInId = result.LinkedInId,
                TwitterId = result.TwitterId
            };
        }

        public async Task<User> GetUserByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetUsers(string username)
        {
            throw new NotImplementedException();
        }

        public void NewUser(CurrentUserPublicProfile user)
        {
            throw new NotImplementedException();
        }

        public void EditUser(CurrentUserPublicProfile userprofile)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}