using System.Data.Entity;
using HotelWebApplication.Dal;

namespace HotelWebApplication.Models
{
    public class HotelDbInitializer : DropCreateDatabaseAlways<HotelContext>
    {
        protected override void Seed(HotelContext db)
        {
            db.Rooms.Add(new Room { RoomLocation = 1, NumberOfPeople = 2, CostPerDay = 2000 });
            db.Rooms.Add(new Room { RoomLocation = 2, NumberOfPeople = 2, CostPerDay = 2100 });
            db.Rooms.Add(new Room { RoomLocation = 3, NumberOfPeople = 2, CostPerDay = 2200 });

            base.Seed(db);
        }
    }
}