using SayMore.Logic.Database;
using SayMore.Logic.Managers;
using SayMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SayMore.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users user)
        {
            if (user.Password == user.PasswordConfirmation)
            {
                UserManager.CreateUser(user);
                return RedirectToAction("Login", "User");
            } else
            {
                return View(user);
            }
            

            
        }
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = UserManager.Login(model.Email, model.Password);
                if(user == null)
                {
                    ModelState.AddModelError("", "Nepareizs lietotājs un/vai parole");
                }
                else
                {
                    Session.Set(UsersModel.FromData(user));
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}