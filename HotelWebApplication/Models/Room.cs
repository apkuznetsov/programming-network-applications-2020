using System.ComponentModel.DataAnnotations;

namespace HotelWebApplication.Models
{
    public class Room
    {
        [Key] public int Id { get; set; }

        public int RoomLocation { get; set; }

        public int NumberOfPeople { get; set; }

        public int CostPerDay { get; set; }

        public string Photo { get; set; }

        public string AdditionalInfo { get; set; }
    }
}