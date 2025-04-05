using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RMSRazorPage.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        [Required, StringLength(20)]
        public string Status { get; set; } // e.g. 'Pending', 'Preparing', 'Served', 'Cancelled'

        // Who placed the order? Possibly a Customer or Staff
        [ForeignKey("Customer")]
        public int? CustomerID { get; set; }
        public Customer Customer { get; set; }

        // Or you can also keep track of the staff who created the order
        [ForeignKey("Staff")]
        public int? StaffID { get; set; }
        public Staff Staff { get; set; }

        // Navigation
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
