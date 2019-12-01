using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HotelWebApplication.Dal;
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

        [HttpGet] public ActionResult Book(int id)
        {
            ViewBag.BookingId = id;

            return View();
        }

        [HttpPost] public string Book(Booking booking)
        {
            booking.BookingDateTime = DateTime.Now;

            db.Bookings.Add(booking);
            db.SaveChanges();

            return "номер забронирован";
        }
    }
}