using System.ComponentModel.DataAnnotations;

namespace RMSRazorPage.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        // Navigation
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();



    }
}
