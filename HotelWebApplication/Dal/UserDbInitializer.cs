using System.Data.Entity;
using HotelWebApplication.Models;

namespace HotelWebApplication.Dal
{
    public class UserDbInitializer : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            db.Users.Add(new User
            {
                Login = "admin",
                Password = "password"
            });

            base.Seed(db);
        }
    }
}