using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoccerLeague.Data;
using SoccerLeague.Models;

namespace SoccerLeague.Pages.Team
{
    public class CreateModel : PageModel
    {
        private readonly SoccerLeague.Data.SoccerLeagueContext _context;

        public CreateModel(SoccerLeague.Data.SoccerLeagueContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SeasonId"] = new SelectList(_context.Set<Models.Season>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Models.Team Team { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Team == null || Team == null)
            {
                return Page();
            }

            _context.Team.Add(Team);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
