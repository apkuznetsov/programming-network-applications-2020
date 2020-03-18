using System.Collections.Generic;
using System.Web.Mvc;
using HotelWebApp.Dal;
using HotelWebApp.Models;

namespace HotelWebApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly HotelContext _db = new HotelContext();

        [Authorize]
        public ActionResult Index()
        {
            return RedirectToAction("All", "Booking");
        }

        [Authorize]
        public ActionResult All()
        {
            IEnumerable<Booking> bookings = _db.Bookings;
            ViewBag.Bookings = bookings;

            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var b = _db.Bookings.Find(id);

            if (b == null) return HttpNotFound();

            _db.Bookings.Remove(b);
            _db.SaveChanges();

            return RedirectToAction("All", "Booking");
        }
    }
}