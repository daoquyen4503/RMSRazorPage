using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RMSRazorPage.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}
