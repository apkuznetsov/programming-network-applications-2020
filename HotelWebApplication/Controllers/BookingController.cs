using HotelWebApplication.Dal;
using System.Web.Mvc;

namespace HotelWebApplication.Controllers
{
    public class BookingController : Controller
    {
        private HotelContext db = new HotelContext();
    }
}