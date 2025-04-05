using RMSRazorPage.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RMSRazorPage.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(20)]
        public string Phone { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}