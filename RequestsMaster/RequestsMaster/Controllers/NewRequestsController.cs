using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RequestsMaster.Models;
using RequestsMaster.Services;
using RequestsMaster.Utility;

namespace RequestsMaster.Controllers
{
    public class NewRequestsController : Controller
    {
        private RequestsService requestsService = new RequestsService();
        // GET: NewRequests
        public ActionResult Index()
        {
            ViewData["requests"] = requestsService.getAllRequestsByUser(ActiveDirectoryUtils.currentUser());
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            bool isAdmin = ActiveDirectoryUtils.isAdmin(System.Web.HttpContext.Current.User.Identity.Name);
            System.Diagnostics.Debug.WriteLine("im there");
            ViewData["Name"] = System.Web.HttpContext.Current.User.Identity.Name;
            ViewData["isAdmin"] = isAdmin;
            return View();
        }
        [HttpPost]
        public ActionResult CreateUserBy(string Name, string GivenName, string Surname, string AccountName, string Password)
        {
            string details = $"Name={Name},GivenName={GivenName},Surname={Surname},AccountName={AccountName},Password={Password}";
            requestsService.newCreateRequest("CREATE", ActiveDirectoryUtils.isAdmin(ActiveDirectoryUtils.currentUser()) ? "APPROVED" : "PENDING", details);
            return new HttpStatusCodeResult(HttpStatusCode.OK);  // OK = 200
        }
        public ActionResult DeleteUser()
        {
            return View();
        }

        public ActionResult DeleteUserBy(string AccountName, string Password)
        {
            string details = $"AccountName={AccountName},Password={Password}";
            requestsService.newCreateRequest("DELETE", ActiveDirectoryUtils.isAdmin(ActiveDirectoryUtils.currentUser()) ? "APPROVED" : "PENDING", details);
            return new HttpStatusCodeResult(HttpStatusCode.OK);  // OK = 200
        }
        public ActionResult EditUser()
        {
            return View();
        }

        public ActionResult EditUserBy(string Name, string GivenName, string Surname, string AccountName, string Password)
        {
            if (Name == "") Name = "?";
            if (GivenName == "") GivenName = "?";
            if (Surname == "") Surname = "?";
            if (AccountName == "") AccountName = "?";
            if (Password == "") Password = "?";
            string details = $"Name={Name},GivenName={GivenName},Surname={Surname},AccountName={AccountName},Password={Password}";
            requestsService.newCreateRequest("EDIT", ActiveDirectoryUtils.isAdmin(ActiveDirectoryUtils.currentUser()) ? "APPROVED" : "PENDING", details);
            return new HttpStatusCodeResult(HttpStatusCode.OK);  // OK = 200
        }

        public ActionResult RequestAdmin()
        {
            return View();
        }

        public ActionResult AdminPage()
        {
            if (ActiveDirectoryUtils.isAdmin(ActiveDirectoryUtils.currentUser()))
            {
                ViewData["requests"] = requestsService.getPendingRequests();
                return View();
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult ChangeRequestStatus(int requestid, string req_status)
        {
            requestsService.changeRequestStatus(requestid, req_status);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}