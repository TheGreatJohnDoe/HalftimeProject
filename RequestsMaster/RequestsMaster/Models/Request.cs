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
        public string type { get; set; }
        public int userId { get; set; }
        public string status { get; set; }
    }
}