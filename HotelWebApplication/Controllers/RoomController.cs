using HotelWebApplication.Dal;
using HotelWebApplication.Models;
using HotelWebApplication.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System;

namespace HotelWebApplication.Controllers
{
    public class RoomController : Controller
    {
        private HotelContext db = new HotelContext();

        [HttpGet]
        public ActionResult All()
        {
            IEnumerable<Room> rooms = db.Rooms;
            ViewBag.Rooms = rooms;

            return View();
        }

        #region редактирование
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Room room = db.Rooms.Find(id);
            if (room != null)
            {
                return View(room);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Room model, HttpPostedFileBase imageData)
        {
            if (imageData != null)
                model.PhotoUrl = ImageSaveHelper.SaveImage(imageData);

            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("All");
            }

            return View("Edit", model);
        }
        #endregion /редактирование

        [HttpGet]
        public ActionResult Book(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Room room = db.Rooms.Find(id);
            if (room != null)
            {
                return View();
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Book(Booking model)
        {
            if (ModelState.IsValid)
            {
                model.BookingDateTime = DateTime.Now;

                db.Bookings.Add(model);
                db.SaveChanges();

                return RedirectToAction("All", "Room");
            }

            return View("Book", model);
        }
    }
}