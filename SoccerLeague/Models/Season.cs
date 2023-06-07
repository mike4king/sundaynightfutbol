using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SoccerLeague.Models
{
    public class Season
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        public virtual ICollection<SeasonTeamBridge> TeamBridges { get; set; }
    }
}
