using Newtonsoft.Json;

namespace DocketSystemAPI.Models
{
    public class SMS
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }
    }
}