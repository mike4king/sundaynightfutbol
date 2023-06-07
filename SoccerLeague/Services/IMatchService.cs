namespace SoccerLeague.Services;

public interface IMatchService
{
    Task<int> GetCurrentSeasonId();
    Task<ICollection<StandingRecord>> GetStandingsBySeasonId(int? seasonId);
}