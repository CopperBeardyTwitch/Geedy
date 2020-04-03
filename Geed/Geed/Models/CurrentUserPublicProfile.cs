using System.Collections.Generic;
using Newtonsoft.Json;

namespace Geed.Models
{
   public  class CurrentUserPublicProfile
    {
        public User User { get; set; }
        public IEnumerable<LatestRating> LatestRatings { get; set; }

        [JsonProperty("UserRating")]
        public int UserAverageRating { get; set; }  

        [JsonProperty("RatingCount")]
        public int RatingCount { get; set; }  
    }
}
    