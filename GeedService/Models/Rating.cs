using Newtonsoft.Json;

namespace GeedService.Models
{
    public class Rating
    {
       
        [JsonProperty("RatedUserName")]
      public string RatedUserName { get; set; }

        [JsonProperty("RaterUsername")]
        public string RaterUserName { get; set; }


        [JsonProperty("GivenRating")]
        public int GivenRating { get; set; }    
    }
}
