using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        public string RoomName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int RoomLevel { get; set; }
        public RoomType RoomType { get; set; } = null!; // Nav Property
        public int RoomTypeId { get; set; } // FK
        public bool IsReserved { get; set; }
        public decimal RoomPrice { get; set; }
    }
}
