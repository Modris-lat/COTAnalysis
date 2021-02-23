using System.Text.Json.Serialization;

namespace ApiService.Models
{
    public class SaveRequest
    {
        [JsonPropertyName("command")]
        public string Command { get; set; }
        [JsonPropertyName("date")]
        public string Date { get; set; }
    }
}
