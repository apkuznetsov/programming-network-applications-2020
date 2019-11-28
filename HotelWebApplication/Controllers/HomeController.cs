using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelWebApplication.Models;

namespace HotelWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private HotelContext db = new HotelContext();

        public ActionResult Index()
        {
            IEnumerable<Room> rooms = db.Rooms;
            ViewBag.Rooms = rooms;

            return View();
        }
    }
}