using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediArch.Models;

namespace MediArch.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            //return View();
            using (DatabaseContext db = new DatabaseContext())
            {
                return View(db.userAccounts.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Person account)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    db.userAccounts.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered";
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Person user)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var usr = db.userAccounts.Single(u => u.CNP == user.CNP && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.Id.ToString();
                    Session["CNP"] = usr.CNP.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "CNP doesn't exist");
                }
                return View();
            }
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}