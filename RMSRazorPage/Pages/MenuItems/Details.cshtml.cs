﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RMSRazorPage.Data;
using RMSRazorPage.Models;

namespace RMSRazorPage.Pages.MenuItems
{
    public class DetailsModel : PageModel
    {
        private readonly RMSRazorPage.Data.ApplicationDbContext _context;

        public DetailsModel(RMSRazorPage.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MenuItem MenuItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.MenuItems.FirstOrDefaultAsync(m => m.MenuItemID == id);
            if (menuitem == null)
            {
                return NotFound();
            }
            else
            {
                MenuItem = menuitem;
            }
            return Page();
        }
    }
}
