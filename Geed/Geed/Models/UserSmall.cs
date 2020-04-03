using Newtonsoft.Json;

namespace Geed.Models
{
    public class UserSmall
    {
        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("UserImage")]
        public string Image { get; set; }   
    }
}