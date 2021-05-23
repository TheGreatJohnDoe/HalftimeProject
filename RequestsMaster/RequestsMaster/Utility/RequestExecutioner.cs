using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using RequestsMaster.Models;
using RequestsMaster.Services;
using RequestsMaster.Utility;

namespace WebApplication1.Utility
{
    public class RequestExecutioner
    {
        public RequestsService requestsService = new RequestsService();

        public RequestExecutioner()
        {
        }

        public void LoopDBForRequests()
        {
            List<Request> waitingForExecution = requestsService.getApprovedUnexecutedRequests();
            foreach (var request in waitingForExecution)
            {
                string[] details = request.req_details.Split(new Char[] { ',', '=' });
                if (request.req_status.ToUpper() == "CREATE")
                {
                    string Name = details[1];
                    string GivenName = details[3];
                    string Surname = details[5];
                    string AccountName = details[7];
                    string Password = details[9];
                    ActiveDirectoryUtils.createUser(Name, GivenName, Surname, AccountName, Password);
                    requestsService.changeRequestStatus(request.id, "EXECUTED");
                }
                else if (request.req_status.ToUpper() == "DELETE")
                {
                    string userid = details[1];
                    ActiveDirectoryUtils.deleteUser(userid);
                    requestsService.changeRequestStatus(request.id, "EXECUTED");
                }
                else if (request.req_status.ToUpper() == "EDIT")
                {
                    string Name = details[1] == "?" ? null : details[1];
                    string GivenName = details[3] == "?" ? null : details[3];
                    string Surname = details[5] == "?" ? null : details[5];
                    string AccountName = details[7] == "?" ? null : details[7];
                    string Password = details[9] == "?" ? null : details[9];
                    ActiveDirectoryUtils.editUser(Name, GivenName, Surname, AccountName, Password);
                    requestsService.changeRequestStatus(request.id, "EXECUTED");
                }
            }
            Thread.Sleep(60000);
        }

        public void AddRequestListener()
        {
            Thread listener = new Thread(new ThreadStart(LoopDBForRequests));
            listener.Start();
        }
    }
}