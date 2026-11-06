using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab8_8razor_postgresql_sudinko.Data;
using wt_lab8_8razor_postgresql_sudinko.Models;

namespace wt_lab8_8razor_postgresql_sudinko.Pages.Flights;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Flight Flight { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var flight = await _context.Flights.FindAsync(id);

        if (flight == null)
        {
            return NotFound();
        }

        Flight = flight;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Flights.Update(Flight);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}