using HotelWebApplication.Dal;
using HotelWebApplication.Models;
using System;
using System.Web.Mvc;

namespace HotelWebApplication.Controllers
{
    public class BookingController : Controller
    {
        private HotelContext db = new HotelContext();

        [HttpGet]
        public ActionResult Book()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Book(Booking booking)
        {
            booking.BookingDateTime = DateTime.Now;

            db.Bookings.Add(booking);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    Booking booking = db.Bookings.Find(id);
        //    if (booking != null)
        //    {
        //        return View(booking);
        //    }
        //    return HttpNotFound();
        //}
    }
}