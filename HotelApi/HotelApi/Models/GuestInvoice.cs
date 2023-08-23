using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class GuestInvoice
    {
        [Key]
        public int InvoiceId { get; set; } // Pk
        [Required]
        public int ReservationId { get; set; }
        public string TsIssued { get; set; } = string.Empty;
        public string TsPaid { get; set; } = string.Empty;
        public string TsCancelled { get; set; } = string.Empty;
    }
}
