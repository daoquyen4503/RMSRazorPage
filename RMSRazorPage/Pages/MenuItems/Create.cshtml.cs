using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMSRazorPage.Models;

public class CreateModel : PageModel
{
    private readonly RMSRazorPage.Data.ApplicationDbContext _context;

    public CreateModel(RMSRazorPage.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    // Đặt SelectList cho dropdown Category
    public SelectList CategoryList { get; set; }

    // Khi GET page, lấy danh sách category
    public async Task<IActionResult> OnGetAsync()
    {
        // Lấy danh sách category từ DB
        CategoryList = new SelectList(await _context.Categories.ToListAsync(), "CategoryID", "Name");
        return Page();
    }

    [BindProperty]
    public MenuItem MenuItem { get; set; } = default!;

    // Khi POST form, lưu MenuItem vào database
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.MenuItems.Add(MenuItem);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
