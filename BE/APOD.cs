using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class APOD
    {
        public string date { get; set; }
        public string explanation { get; set; }
        public string media_type { get; set; }
        public string service_version { get; set; }
        public string title { get; set; } = "Loading...";
        public string url { get; set; }
    }
}
