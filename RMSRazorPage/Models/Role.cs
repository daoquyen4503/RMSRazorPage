﻿using System.ComponentModel.DataAnnotations;

namespace RMSRazorPage.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Required, StringLength(50)]
        public string RoleName { get; set; } // e.g. Manager, Waiter, Chef, Cashier
    }
}
