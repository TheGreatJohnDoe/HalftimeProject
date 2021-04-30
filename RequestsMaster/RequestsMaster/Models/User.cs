using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequestsMaster.Models
{
    public class User
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string userRole { get; set; }
        static public string toString()
        {
            return "Omer";
        }
    }
}