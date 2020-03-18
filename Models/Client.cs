using System.ComponentModel.DataAnnotations;

namespace HotelWebApp.Models
{
    public class Client
    {
        [Key] public int Id { get; set; }

        public int PassportSeriesAndNumber { get; set; }

        public string FullName { get; set; }
    }
}