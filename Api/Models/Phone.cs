using System.Text.Json.Serialization;

namespace Api.Models
{
    public class Phone
    {
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("data")]
        public Dictionary<string, string>? Data { get; set; }
    }
   
}
