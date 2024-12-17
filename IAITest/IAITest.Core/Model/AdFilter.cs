using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IAITest.Core.Model
{
    public class AdFilter
    {
        [JsonPropertyName("location")]
        public Location? Location { get; set; }
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}
