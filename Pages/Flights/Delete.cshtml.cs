using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab8_8razor_postgresql_sudinko.Data;
using wt_lab8_8razor_postgresql_sudinko.Models;

namespace wt_lab8_8razor_postgresql_sudinko.Pages.Flights;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    public Flight? Flight { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Flight = await _context.Flights.FindAsync(id);

        if (Flight == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var flight = await _context.Flights.FindAsync(id);

        if (flight != null)
        {
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}