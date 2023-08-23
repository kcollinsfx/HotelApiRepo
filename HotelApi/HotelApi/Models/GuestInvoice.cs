using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class GuestInvoice
    {
        [Key]
        public int InvoiceId { get; set; } // Pk
        [Required]
        
        public string TsIssued { get; set; } = string.Empty;
        public string TsPaid { get; set; } = string.Empty;
        public string TsCancelled { get; set; } = string.Empty;

        public Reservation Reservation { get; set; } = null!;
        public int ReservationId { get; set; }
    }
}
