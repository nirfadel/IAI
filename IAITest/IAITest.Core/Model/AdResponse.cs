using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IAITest.Core.Model
{
    public class AdResponse
    {
        public HttpStatusCode Status { get; set; }
        public string Error { get; set; }
    }
}
