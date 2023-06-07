using Microsoft.EntityFrameworkCore;
using SoccerLeague.Data;

namespace SoccerLeague.Services
{
    public class MatchService : IMatchService
    {
        private readonly SoccerLeagueContext _context;

        public MatchService(SoccerLeagueContext context)
        {
            _context = context;
        }

        public async Task<int> GetCurrentSeasonId()
        {
            return await _context.Season.OrderByDescending(r => r.Id).Take(1).Select(r => r.Id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<StandingRecord>> GetStandingsBySeasonId(int? seasonId)
        {
            seasonId ??= await GetCurrentSeasonId();

            var standings = await _context.Team.Where(r => r.SeasonBridges.Any(b => b.SeasonId == seasonId)).Select(r => new StandingRecord()
            {
                TeamId = r.Id,
                TeamName = r.Name
            }).ToListAsync();

            foreach (var s in standings)
            {
                var homeMatches = await _context.Match.Where(r => r.HomeTeamId == s.TeamId && r.SeasonId == seasonId).ToListAsync();
                var awayMatches = await _context.Match.Where(r => r.AwayTeamId == s.TeamId && r.SeasonId == seasonId).ToListAsync();

                foreach (var m in homeMatches)
                {
                    s.GamesPlayed++;
                    if (m.HomeTeamScore > m.AwayTeamScore)
                        s.GamesWon++;
                    else if (m.AwayTeamScore > m.HomeTeamScore)
                        s.GamesLost++;

                    s.ScoreDifferential += m.HomeTeamScore ?? 0;
                    s.ScoreDifferential -= m.AwayTeamScore ?? 0;
                }

                foreach (var m in awayMatches)
                {
                    s.GamesPlayed++;
                    if (m.HomeTeamScore < m.AwayTeamScore)
                        s.GamesWon++;
                    else if (m.AwayTeamScore < m.HomeTeamScore)
                        s.GamesLost++;

                    s.ScoreDifferential += m.AwayTeamScore ?? 0;
                    s.ScoreDifferential -= m.HomeTeamScore ?? 0;
                }

                s.GamesTied = s.GamesPlayed - s.GamesWon - s.GamesLost;
                s.Points = (s.GamesWon * 3) + (s.GamesTied * 1);
            }

            return standings.OrderByDescending(r => r.Points).ThenByDescending(r => r.ScoreDifferential).ToList();
        }
    }
}
