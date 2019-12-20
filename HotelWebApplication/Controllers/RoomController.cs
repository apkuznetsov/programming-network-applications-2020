using HotelWebApplication.Dal;
using HotelWebApplication.Models;
using HotelWebApplication.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

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
                ViewBag.PhotoUrl = room.PhotoUrl;
                return View(room);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Room model, HttpPostedFileBase imageData)
        {
            //Room oldRoom = null;

            if (imageData != null)
            {
                model.PhotoUrl = ImageSaveHelper.SaveImage(imageData);
            }
            //else
            //{
            //    oldRoom = db.Rooms.Find(model.Id);
            //    model.PhotoUrl = oldRoom.PhotoUrl;
            //}

            if (ModelState.IsValid)
            {
                //if (!areRoomsEqual(oldRoom, model))
                //{
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                //}

                return RedirectToAction("All");
            }

            return View("Edit", model);
        }

        //private bool areRoomsEqual(Room r1, Room r2)
        //{
        //    if (r1 == null)
        //        return false;
        //    if (r2 == null)
        //        return false;

        //    if (r1.Id != r2.Id)
        //        return false;
        //    if (r1.Name != r2.Name)
        //        return false;
        //    if (r1.NumberOfPeople != r2.NumberOfPeople)
        //        return false;
        //    if (r1.CostPerDay != r2.CostPerDay)
        //        return false;
        //    if (r1.PhotoUrl != r2.PhotoUrl)
        //        return false;
        //    if (r1.Description != r2.Description)
        //        return false;

        //    return true;
        //}
        [HttpGet]
        public ActionResult Book()
        {
            return HttpNotFound();
        }

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