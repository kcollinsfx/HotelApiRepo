using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; } // PK
        [Required]
        public string Email { get; set; } = string.Empty;

        public bool HasPassword { get; set; }
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int GuestId { get; set; } // FK
        public Guest Guest { get; set; } = null!; // Nav Property
    }
}
