using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RMSRazorPage.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required, StringLength(20)]
        public string Status { get; set; } // e.g. 'Pending', 'Confirmed', 'Completed', 'Cancelled'

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Table")]
        public int TableID { get; set; }
        public Table Table { get; set; }

        // Navigation
        public Payment Payment { get; set; }
    }
}
