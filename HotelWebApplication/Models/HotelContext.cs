using System.Data.Entity;

namespace HotelWebApplication.Models
{
    public class HotelContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Booking>().HasKey(table => new {
                table.RoomLocation,
                table.ArrivalDateTime,
                table.DepartureDateTime
            });
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}