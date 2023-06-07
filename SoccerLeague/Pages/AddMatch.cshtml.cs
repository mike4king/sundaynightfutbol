using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoccerLeague.Models;

namespace SoccerLeague.Pages
{
    public class AddMatchModel : PageModel
    {
        private readonly SoccerLeague.Data.SoccerLeagueContext _context;

        public AddMatchModel(SoccerLeague.Data.SoccerLeagueContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Teams"] = new SelectList(_context.Team, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Match Match { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Match == null || Match == null)
            {
                return Page();
            }

            if (Match.HomeTeamId == Match.AwayTeamId)
                return Page();

            if (Match.HomeTeamScore > Match.AwayTeamScore + 4)
                Match.HomeTeamScore = Match.AwayTeamScore + 4;
            if (Match.AwayTeamScore > Match.HomeTeamScore + 4)
                Match.AwayTeamScore = Match.HomeTeamScore + 4;

            _context.Match.Add(Match);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
