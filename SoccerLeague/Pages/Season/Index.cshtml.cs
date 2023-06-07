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
    public class IndexModel : PageModel
    {
        private readonly SoccerLeague.Data.SoccerLeagueContext _context;

        public IndexModel(SoccerLeague.Data.SoccerLeagueContext context)
        {
            _context = context;
        }

        public IList<Models.Season> Season { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Season != null)
            {
                Season = await _context.Season.ToListAsync();
            }
        }
    }
}
