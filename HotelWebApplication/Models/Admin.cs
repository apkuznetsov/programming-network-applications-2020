using System.ComponentModel.DataAnnotations;

namespace HotelWebApplication.Models
{
    public class Admin
    {
        [Key] public string Login { get; set; }

        public string Password { get; set; }
    }
}