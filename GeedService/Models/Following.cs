using Newtonsoft.Json;

namespace GeedService.Models
{
    public class Following
    {
       
        [JsonProperty("Follower")]
        public string FollowerUserName { get; set; }

        [JsonProperty("Followed")]
        public string FollowedUserName { get; set; }  
    }
}
