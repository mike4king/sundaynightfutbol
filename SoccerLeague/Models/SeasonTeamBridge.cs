namespace SoccerLeague.Models
{
    public class SeasonTeamBridge
    {
        public int SeasonId { get; set; }
        public virtual Season Season { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
