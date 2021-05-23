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
        private RequestRepository requestsRepository = new RequestRepository();
        public void newCreateRequest(string req_type, string req_status, string req_details)
        {
            DateTime created = DateTime.Now;
            string userid = System.Web.HttpContext.Current.User.Identity.Name;
            Request request = new Request(0, created, req_type, userid, req_status, req_details);
            requestsRepository.newRequest(request);
        }

        public List<Request> getAllRequestsByUser(string userid)
        {
            return requestsRepository.getAllRequestsByUser(userid);
        }

        public List<Request> getPendingRequests()
        {
            return requestsRepository.getPendingRequests();
        }

        public void changeRequestStatus(int requestid, string req_status)
        {
            requestsRepository.changeRequestStatus(requestid, req_status);
        }

        public List<Request> getApprovedUnexecutedRequests()
        {
            return requestsRepository.getApprovedUnexecutedRequests();
        }
    } 
}