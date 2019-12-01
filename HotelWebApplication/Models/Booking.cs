using System;
using System.ComponentModel.DataAnnotations;

namespace HotelWebApplication.Models
{
    public class Booking
    {
        [Key] public int Id { get; set; }

        public virtual Client Client { get; set; }

        public virtual Room Room { get; set; }

        public DateTime BookingDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public int OrderPrice { get; set; }
    }
}