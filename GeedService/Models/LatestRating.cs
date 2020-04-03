using System;
using Newtonsoft.Json;

namespace GeedService.Models
{
   public class LatestRating
    {
        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("RatingGiven")]
        public int RatingGiven { get; set; }

        [JsonProperty("DateOfRating")]
        public DateTime TimeOfRating { get; set; }   
    }
}
