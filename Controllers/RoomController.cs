using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelWebApp.Dal;
using HotelWebApp.Helpers;
using HotelWebApp.Models;

namespace HotelWebApp.Controllers
{
    public class RoomController : Controller
    {
        private static readonly int PageSize = 5;

        private readonly HotelContext _db = new HotelContext();

        [Authorize]
        public ActionResult All()
        {
            IEnumerable<Room> rooms = _db.Rooms;
            ViewBag.Rooms = rooms;

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Search(string search)
        {
            IEnumerable<Room> rooms = _db.Rooms.Where(
                r => r.Name.Contains(search) ||
                     r.Description.Contains(search)).ToList();

            return PartialView(rooms);
        }

        [Authorize]
        public ActionResult Book(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var room = _db.Rooms.Find(id);
            if (room != null)
            {
                ViewBag.RoomId = room.Id;

                return View();
            }

            return HttpNotFound();
        }

        [Authorize]
        public ActionResult Book(Booking model)
        {
            model.BookingDateTime = DateTime.Now;

            #region проверка номера комнаты

            var room = _db.Rooms.FirstOrDefault(
                r => r.Id == model.RoomId);

            if (room == null)
            {
                ModelState.AddModelError(string.Empty, "Комната под таким номером не существует");
                return View("Book", model);
            }

            #endregion /проверка номера комнаты

            #region проверка клиента

            var client = _db.Clients.FirstOrDefault(
                c => c.PassportSeriesAndNumber == model.ClientPassportSeriesAndNumber);

            if (client == null) // если нет такого -- создаём
            {
                var passportSeriesAndNumber = model.ClientPassportSeriesAndNumber;
                var fullName = model.ClientFullName;
                var c = new Client
                {
                    PassportSeriesAndNumber = passportSeriesAndNumber,
                    FullName = fullName
                };

                _db.Clients.Add(c);
            }
            else // если есть -- проверяем ФИО
            {
                if (client.FullName != model.ClientFullName)
                {
                    ModelState.AddModelError(string.Empty,
                        "ФИО клиента не соответсвует серии и номеру паспорта в базе");
                    model.ClientFullName = client.FullName;
                    return View("Book", model);
                }
            }

            #endregion /проверка клиента

            _db.Bookings.Add(model);
            _db.SaveChanges();

            return RedirectToAction("All", "Room");
        }

        #region редактирование

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();

            var room = _db.Rooms.Find(id);
            if (room != null) return View(room);

            return HttpNotFound();
        }

        [Authorize]
        public ActionResult Edit(Room model, HttpPostedFileBase imageData)
        {
            if (imageData != null)
                model.PhotoUrl = ImageSaveHelper.SaveImage(imageData);

            if (!ModelState.IsValid) return View("Edit", model);
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("All");
        }

        #endregion /редактирование

        [Authorize]
        public ActionResult Index()
        {
            PagedData<Room> pagedRooms = new PagedData<Room>
            {
                Data = _db.Rooms.OrderBy(r => r.Name).Skip(PageSize * 0).Take(PageSize).ToList(),
                TotalPages = Convert.ToInt32(Math.Ceiling((double) _db.Rooms.Count() / PageSize)),
                CurrentPage = 1
            };

            return View(pagedRooms);
        }

        [Authorize]
        [HttpPost]
        public ActionResult RoomsList(int pageNum)
        {
            PagedData<Room> pagedRooms = new PagedData<Room>
            {
                Data = _db.Rooms.OrderBy(r => r.Name).Skip(PageSize * (pageNum - 1)).Take(PageSize).ToList(),
                TotalPages = Convert.ToInt32(Math.Ceiling((double) _db.Rooms.Count() / PageSize)),
                CurrentPage = pageNum
            };

            return PartialView("RoomsList", pagedRooms);
        }
    }
}