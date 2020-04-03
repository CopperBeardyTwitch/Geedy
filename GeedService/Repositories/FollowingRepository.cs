using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeedService.Interfaces;
using GeedService.Model;


namespace GeedService.Repositories
{
    public class FollowingRepository :IFollowingRepository
    {
        //Todo implement Following repository
        public List<Following> GetFollowedUsers(string currentUserId)
        {
            throw new NotImplementedException();
        }

        public bool AddNewFollowedUser(Following following)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFollowedUser(Following following)
        {
            throw new NotImplementedException();
        }
    }
}
