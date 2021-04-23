using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.Domain
{
     public class Standing : BaseEntity
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

          public Team Team { get; set; }
          public League League { get; set; }

          public string Golaverage(int goalsScored, int goalsReceived)
          {
               GoalsReceived = goalsReceived;
               GoalsScored = goalsScored;

               int result = goalsScored - goalsReceived;

               return result.ToString();
          }
     }
}
