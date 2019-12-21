using HotelWebApplication.Dal;
using HotelWebApplication.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HotelWebApplication.Controllers
{
    public class BookingController : Controller
    {
        private HotelContext db = new HotelContext();

        public ActionResult Index()
        {
            return RedirectToAction("All", "Hotel");
        }

        public ActionResult All()
        {
            IEnumerable<Booking> bookings = db.Bookings;
            ViewBag.Bookings = bookings;

            return View();
        }
    }
}