using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SoccerLeague.Data;
using SoccerLeague.Models;

namespace SoccerLeague.Pages.Season
{
    public class DetailsModel : PageModel
    {
        private readonly SoccerLeague.Data.SoccerLeagueContext _context;

        public DetailsModel(SoccerLeague.Data.SoccerLeagueContext context)
        {
            _context = context;
        }

      public Models.Season Season { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Season == null)
            {
                return NotFound();
            }

            var season = await _context.Season.FirstOrDefaultAsync(m => m.Id == id);
            if (season == null)
            {
                return NotFound();
            }
            else 
            {
                Season = season;
            }
            return Page();
        }
    }
}
