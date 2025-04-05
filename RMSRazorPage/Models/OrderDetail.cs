using System.ComponentModel.DataAnnotations;

namespace RMSRazorPage.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int MenuItemID { get; set; }
        public MenuItem MenuItem { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
