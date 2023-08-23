using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class ReservedRoom
    {
        [Key]
        public int ReservedRoomId { get; set; }
        [Required]
        public Room Room { get; set; } = null!; // Nav Property
        public int RoomId { get; set; } // FK
        public Reservation Reservation { get; set; } = null!; // Nav Property
        public int ReservationId { get; set; } // FK
    }
}
