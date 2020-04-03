using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeedService.Model;


namespace GeedService.Interfaces
{
    public interface IFollowingRepository
    {
        List<Following> GetFollowedUsers(string currentUserId);
        bool AddNewFollowedUser(Following following);

        bool RemoveFollowedUser(Following following);
    }
}
