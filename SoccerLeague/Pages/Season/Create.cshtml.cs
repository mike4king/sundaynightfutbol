using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoccerLeague.Data;
using SoccerLeague.Models;

namespace SoccerLeague.Pages.Season
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
            return Page();
        }

        [BindProperty]
        public Models.Season Season { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Season == null || Season == null)
            {
                return Page();
            }

            _context.Season.Add(Season);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
