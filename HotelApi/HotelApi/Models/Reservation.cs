using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        [Required]
        public int GuestId { get; set; } // FK
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public string TsCreated { get; set; } = string.Empty;
        public string TsUpdated { get; set; } = string.Empty;
        public decimal totalPrice { get; set; }

        public Guest Guest { get; set; } = null!; // Nav Property
    }
}
