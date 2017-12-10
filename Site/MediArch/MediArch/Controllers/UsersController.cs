using Microsoft.AspNetCore.Mvc;
using MediArch.Data;

namespace MediArch.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataService _context;

        public UsersController(DataService context)
        {
            _context = context;
        }

        //Registration Action
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        // Registration POST Action

        // Login

        // Login POST

        // Logout

        //Verify Email

        //Verify Email Link

        [HttpGet]
        public ActionResult AllUsers()
        {
            return View();
        }
    }
}
