using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IAITest.Core.Model
{
    public class AdUpdate
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Location? Location { get; set; }
    }
}
