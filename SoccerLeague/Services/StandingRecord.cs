namespace SoccerLeague.Services;

public class StandingRecord
{
    public int TeamId { get; set; }
    public string TeamName { get; set; }
    public int GamesPlayed { get; set; }
    public int GamesWon { get; set; }
    public int GamesTied { get; set; }
    public int GamesLost { get; set; }
    public int ScoreDifferential { get; set; }
    public int Points { get; set; }

}