using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RMSRazorPage.Data;
using RMSRazorPage.Models;

namespace RMSRazorPage.Pages.OrderDetails
{
    public class CreateModel : PageModel
    {
        private readonly RMSRazorPage.Data.ApplicationDbContext _context;

        public CreateModel(RMSRazorPage.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MenuItemID"] = new SelectList(_context.MenuItems, "MenuItemID", "Name");
        ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "Status");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderDetails.Add(OrderDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
