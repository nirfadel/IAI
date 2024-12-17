using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IAITest.Core.Model
{
    public class Location
    {
        [JsonPropertyName("lat")]
        public decimal Lat { get; set; }
        [JsonPropertyName("lng")]
        public decimal Lng { get; set; }
    }
}
