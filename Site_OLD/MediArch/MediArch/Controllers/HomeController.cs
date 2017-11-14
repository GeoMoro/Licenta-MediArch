using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediArch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to MediArch";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "MediArch -> Contact page.";

            return View();
        }
    }
}