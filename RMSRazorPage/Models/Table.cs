using System.ComponentModel.DataAnnotations;

namespace RMSRazorPage.Models
{
    public class Table
    {
        [Key]
        public int TableID { get; set; }

        [Required]
        public int Capacity { get; set; } // Number of seats

        [Required, StringLength(50)]
        public string Status { get; set; } // e.g. 'Available', 'Occupied', 'Reserved'
    }
}
