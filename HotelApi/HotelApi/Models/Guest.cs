using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; } // PK
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DOB { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string TsCreated { get; set; } = string.Empty;
        public string TsUpdated { get; set;} = string.Empty;

        // One to One relationship with the Login entity table
        public Login Login { get; set; } = null!;
        // One to Many relationship with the Reservations entity table
        public List<Reservation> Reservations { get; set; } = null!;
    }
}
