using LoginAndRegister.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAndRegister.Controllers
{
    public class HomeController : Controller
    {
        private IDbOperations db;
        private IWebHostEnvironment hostingEnvironment;

        public HomeController(IDbOperations db, IWebHostEnvironment hostingEnvironment)
        {
            this.db = db;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ViewResult Index()
        {
            return View();
        }
        public new ViewResult User(string message)
        {
            ViewData["Message"] = message;
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Account acc = db.IsExists(model.Email);
                if (acc == null)
                {
                    Account account = db.AddAccount(model.Name, model.Email, model.Password);
                    User("Hi " + account.Name);
                    return View("User");
                }
                else
                {
                    User("This Email is already registered");
                    return View("User");
                }
            }
            return View();
        }
        [HttpPost]
        public ViewResult Login(LoginViewModel model)
        {
            Account account = db.GetAccount(model.Email, model.Password);
            if (account != null)
            {
                User("Hi " + account.Name);
            }
            else
            {
                User("Invalid Login Credentials");
            }
            return View("User");
        }

    }
}
