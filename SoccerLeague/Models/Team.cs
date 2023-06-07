using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerLeague.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Color { get; set; }
        
        public virtual ICollection<SeasonTeamBridge> SeasonBridges { get; set; }
    }
}
