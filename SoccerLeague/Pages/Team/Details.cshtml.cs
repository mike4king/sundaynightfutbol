using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SoccerLeague.Data;
using SoccerLeague.Models;

namespace SoccerLeague.Pages.Team
{
    public class DetailsModel : PageModel
    {
        private readonly SoccerLeague.Data.SoccerLeagueContext _context;

        public DetailsModel(SoccerLeague.Data.SoccerLeagueContext context)
        {
            _context = context;
        }

      public Models.Team Team { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Team == null)
            {
                return NotFound();
            }

            var team = await _context.Team.FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            else 
            {
                Team = team;
            }
            return Page();
        }
    }
}
