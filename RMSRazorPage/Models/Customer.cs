using System.ComponentModel.DataAnnotations;

namespace RMSRazorPage.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(20)]
        public string Phone { get; set; }

        // Navigation
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

