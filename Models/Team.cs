using System.ComponentModel.DataAnnotations;

namespace Tournaments.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; } // Primary Key
        public int TournamentId { get; set; } // Foreign Key
        public string TeamName { get; set; }

        // Navigation Property
        public Tournament Tournament { get; set; }
        
    }
}
