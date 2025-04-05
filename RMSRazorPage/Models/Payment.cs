using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RMSRazorPage.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required, StringLength(20)]
        public string PaymentMethod { get; set; } // e.g. 'Credit Card', 'Cash', 'Online'

        [ForeignKey("Reservation")]
        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; }
    }
}
