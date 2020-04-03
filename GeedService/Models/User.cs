using Newtonsoft.Json;

namespace GeedService.Models
{
    public class User  
    {
       [JsonProperty("UserName")]
        public string Username { get; set; }

        [JsonProperty("Bio")]
        public string Bio { get; set; }

        [JsonProperty("Image")]
        public string ImageUrl { get; set; }

        [JsonProperty("FacebookId")]
        public string FacebookId { get; set; }

        [JsonProperty("TwitterId")]
        public string TwitterId { get; set; }

        [JsonProperty("LinkedinId")]
        public string LinkedInId { get; set; }

        [JsonProperty("InstagramId")]
        public string InstagramId { get; set; }

       
    }
}
