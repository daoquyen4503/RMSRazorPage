using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RMSRazorPage.Data;
using RMSRazorPage.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RMSRazorPage.Pages.Categories
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
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("Connection String: " + _context.Database.GetDbConnection().ConnectionString);

            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        // In lỗi ra console để debug
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return Page();
            }

            try
            {
                _context.Categories.Add(Category);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu danh mục: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Lỗi bên trong: {ex.InnerException.Message}");
                }
                ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi khi lưu danh mục. Vui lòng thử lại.");
                return Page();
            }
        }
    }
}