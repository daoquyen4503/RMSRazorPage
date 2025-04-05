using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RMSRazorPage.Data;
using RMSRazorPage.Models;

namespace RMSRazorPage.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly RMSRazorPage.Data.ApplicationDbContext _context;

        public IndexModel(RMSRazorPage.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Role> Role { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Role = await _context.Roles.ToListAsync();
        }
    }
}
