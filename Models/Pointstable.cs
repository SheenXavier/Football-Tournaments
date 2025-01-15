using System.ComponentModel.DataAnnotations;
using Tournaments.Models;

namespace Tournaments.Models
{
    public class Pointstable
    {
        [Key]
        public int Id { get; set; } // Primary Key
        public int TournamentId { get; set; } // Foreign Key
        public int TeamId { get; set; } // Foreign Key
        public int Played { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
        public int Points { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }

        // Navigation Properties
        public Tournament Tournament { get; set; }
        public Team Team { get; set; }
    }
}
