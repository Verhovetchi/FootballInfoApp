using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.Domain
{
     public class Match : BaseEntity
     {
          [Required]
          public int LeagueId { get; set; }

          [Required]
          public int HomeTeamId { get; set; }

          [Required]
          public int AwayTeamId { get; set; }

          public int HomeTeamScored { get; set; }

          public int AwayTeamScored { get; set; }

          [Required]
          public int StadiumId { get; set; }

          public League League { get; set; }
     }
}
