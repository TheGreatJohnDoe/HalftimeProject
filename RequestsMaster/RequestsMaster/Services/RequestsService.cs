using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RequestsMaster.Models;
using RequestsMaster.Repositories;

namespace RequestsMaster.Services
{
    public class RequestsService
    {
        private RequestRepository requestsRepository;
        public void newCreateRequest(string req_type, string req_status)
        {
            DateTime created = DateTime.Now;
            string userid = System.Web.HttpContext.Current.User.Identity.Name;


        }

        public List<Request> getAllRequestsByUser(string userid)
        {
            return requestsRepository.getAllRequestsByUser(userid);
        }
    }
}