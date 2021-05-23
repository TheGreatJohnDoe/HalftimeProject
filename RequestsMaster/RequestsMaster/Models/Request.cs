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
        public Request(int id, DateTime created, string req_type, string userid, string req_status, string req_details)
        {
            this.id = id;
            this.created = created;
            this.req_type = req_type;
            this.userid = userid;
            this.req_status = req_status;
            this.req_details = req_details;
        }
    }
}