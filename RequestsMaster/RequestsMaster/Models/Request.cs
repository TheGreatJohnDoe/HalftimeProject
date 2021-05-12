using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequestsMaster.Models
{
    public class Request
    {
        public int id { get; set; }
        public DateTime created { get; set; }
        public string req_type { get; set; }
        public string userid { get; set; }
        public string req_status { get; set; }
        public string req_details { get; set; }
    }
}