using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class GuestInvoice
    {
        [Key]
        public int InvoiceId { get; set; } // Pk
        [Required]
        public int ReservationId { get; set; }
        public DateTime TsIssued { get; set; }
        public DateTime TsPaid { get; set; }
        public DateTime TsCancelled { get; set; }
    }
}
