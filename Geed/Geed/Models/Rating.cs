using Newtonsoft.Json;

namespace Geed.Models
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
