using System.ComponentModel.DataAnnotations;

namespace HotelWebApplication.Models
{
    public class Client
    {
        [Key] public int ClientPassportSeriesAndNumber { get; set; }

        public string FullName { get; set; }
    }
}