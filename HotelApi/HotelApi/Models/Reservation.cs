using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        [Required]
        public int GuestId { get; set; } // FK
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime TsCreated { get; set; }
        public DateTime TsUpdated { get; set;}
        public decimal totalPrice { get; set; }

        public Guest Guest { get; set; } = null!; // Nav Property
    }
}
