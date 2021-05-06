using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RequestsMaster.Models;

namespace RequestsMaster.Controllers
{
    public class NewRequestsController : Controller
    {
        // GET: NewRequests
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUserBy(string Name, string GivenName, string Surname, string AccountName, string Password)
        {
            string details = $"Name:{Name},GivenName:{GivenName},Surname:{Surname},AccountName:{AccountName},Password:{Password}";
            ; ;
            
        }
        public ActionResult DeleteUser()
        {
            return View();
        }

        public ActionResult EditUser()
        {
            return View();
        }

        public ActionResult RequestAdmin()
        {
            return View();
        }
    }
}