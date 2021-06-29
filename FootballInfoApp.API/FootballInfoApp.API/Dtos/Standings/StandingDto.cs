using FootballInfoApp.Domain;
using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.API.Dtos.Standings
{
     public class StandingDto
     {
          [Required]
          public int TeamId { get; set; }

          public int LeagueId { get; set; }

          [Required]
          public int NumberOfMatches { get; set; }

          [Required]
          public int Wins { get; set; }

          [Required]
          public int Draws { get; set; }

          [Required]
          public int Loses { get; set; }

          [Required]
          public int GoalsScored { get; set; }

          [Required]
          public int GoalsReceived { get; set; }

          [Required]
          public int Points { get; set; }

          public virtual Team Team { get; set; }
          public virtual League League { get; set; }
     }
}
