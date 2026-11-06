using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_sudinko.Data;
using wt_lab8_8razor_postgresql_sudinko.Models;

namespace wt_lab8_8razor_postgresql_sudinko.Pages.Flights;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Flight> Flights { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public async Task OnGetAsync()
    {
        var query = _context.Flights.AsQueryable();

        if (!string.IsNullOrWhiteSpace(Search))
        {
            query = query.Where(f => f.Number.Contains(Search));
        }

        Flights = await query
            .OrderBy(f => f.Number)
            .ToListAsync();
    }
}