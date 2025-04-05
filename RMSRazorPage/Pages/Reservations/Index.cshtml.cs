using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RMSRazorPage.Data;
using RMSRazorPage.Models;

namespace RMSRazorPage.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly RMSRazorPage.Data.ApplicationDbContext _context;

        public IndexModel(RMSRazorPage.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Reservation = await _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.Table).ToListAsync();
        }
    }
}
