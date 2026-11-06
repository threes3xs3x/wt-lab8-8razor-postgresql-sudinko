using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab8_8razor_postgresql_sudinko.Data;
using wt_lab8_8razor_postgresql_sudinko.Models;

namespace wt_lab8_8razor_postgresql_sudinko.Pages.Flights;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Flight Flight { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Flights.Add(Flight);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}