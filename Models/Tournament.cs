using System.ComponentModel.DataAnnotations;
using Tournaments.Models;
    
namespace Tournaments.Models
{
    public class Tournament
    {
        [Key]
        public int TournamentId { get; set; } // Primary Key
        public string TourName { get; set; }

        // Navigation Property
        public ICollection<Team> Team { get; set; }
    }
}
