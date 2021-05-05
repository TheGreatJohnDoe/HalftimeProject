using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RequestsMaster.Controllers
{
    public class NewRequestsController : Controller
    {
        // GET: NewRequests
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
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