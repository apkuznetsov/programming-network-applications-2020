﻿using HotelWebApplication.Dal;
using HotelWebApplication.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace HotelWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private HotelContext db = new HotelContext();

        public ActionResult Index()
        {
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в БД
                User user = null;
                user = db.Users.FirstOrDefault(
                    u => u.Login == model.Name &&
                    u.Password == model.Password);


                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("All", "Room");
                }
                else
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}