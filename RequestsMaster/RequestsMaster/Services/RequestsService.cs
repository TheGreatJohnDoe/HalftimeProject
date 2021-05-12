using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequestsMaster.Services
{
    public class RequestsService
    {
        public void newCreateRequest(string req_type, string req_status, )
        {
            DateTime created = DateTime.Now;
            string userid = System.Web.HttpContext.Current.User.Identity.Name;


        }
    }
}