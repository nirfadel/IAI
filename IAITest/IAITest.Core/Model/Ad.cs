using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static IAITest.Core.Utils.Enums;

namespace IAITest.Core.Model
{
    public class Ad
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        public Location? Location { get; set; }
        public DateTime AdDate { get; set; }
        public DateTime AdUpdateDate { get; set; }
        public bool IsDeleted { get; set; } 
        public AdType AdType { get; set; }

    }
}
