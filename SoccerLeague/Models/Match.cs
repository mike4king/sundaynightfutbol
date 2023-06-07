using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerLeague.Models
{
    public class Match
    {
        [Key]
        public int? Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        public int HomeTeamId { get; set; }
        [Range(0, 20, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? HomeTeamScore { get; set; }
        public int AwayTeamId { get; set; }
        [Range(0, 20, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? AwayTeamScore { get; set; }
        public int SeasonId { get; set; }

        [ForeignKey("HomeTeamId")]
        public virtual Team HomeTeam { get; set; }
        [ForeignKey("AwayTeamId")]
        public virtual Team AwayTeam { get; set; }
        [ForeignKey("SeasonId")]
        public virtual Season Season { get; set; }
    }
}
