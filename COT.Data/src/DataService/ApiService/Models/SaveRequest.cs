using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
