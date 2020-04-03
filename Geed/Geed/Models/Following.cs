using Newtonsoft.Json;

namespace Geed.Models
{
    public class Following
    {
       
        [JsonProperty("Follower")]
        public string FollowerUserName { get; set; }

        [JsonProperty("Followed")]
        public string FollowedUserName { get; set; }  
    }
}
