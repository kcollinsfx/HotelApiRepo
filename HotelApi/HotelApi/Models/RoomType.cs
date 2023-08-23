using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class RoomType
    {
        [Key]
        public int RoomTypeId { get; set; } // PK

        [Required]
        public string RoomTypeName { get; set; } = string.Empty;
        public bool IsAccessible { get; set; }
    }
}
