using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoccerLeague.Data;
using SoccerLeague.Services;

namespace SoccerLeague.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMatchService _matchService;
        private readonly SoccerLeagueContext _context;
        public ICollection<StandingRecord> Standings { get; set; } = new List<StandingRecord>();
        public SelectList Seasons { get; set; }
        [DisplayName("Season")]
        public int? SeasonId { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IMatchService matchService, SoccerLeagueContext context)
        {
            _logger = logger;
            _matchService = matchService;
            _context = context;
        }

        public async Task OnGet()
        {
            await SetupPage(null);
        }

        public async Task<IActionResult> OnPostAsync(int seasonId)
        {
            await SetupPage(seasonId);
            return Page();
        }

        private async Task SetupPage(int? seasonId)
        {
            SeasonId = seasonId ?? await _matchService.GetCurrentSeasonId();
            Standings = await _matchService.GetStandingsBySeasonId(SeasonId);
            var seasons = await _context.Season.OrderByDescending(r => r.Id).ToListAsync();
            Seasons = new SelectList(seasons, "Id", "Name");
        }
    }
}