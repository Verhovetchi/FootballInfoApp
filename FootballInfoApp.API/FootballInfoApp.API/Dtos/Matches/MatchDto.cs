using FootballInfoApp.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.API.Dtos.Matches
{
     public class MatchDto
     {
          [Required]
          public int LeagueId { get; set; }

          [Required]
          public int Tour { get; set; }

          [Required]
          public int HomeTeamId { get; set; }

          [Required]
          public int AwayTeamId { get; set; }

          public int? HomeTeamScored { get; set; }

          public int? AwayTeamScored { get; set; }

          public DateTime? MatchDate { get; set; }

          [Required]
          public int StadiumId { get; set; }

          public virtual League League { get; set; }

          //[NotMapped]
          public virtual Team HomeTeam { get; set; }

          //[NotMapped]
          public virtual Team AwayTeam { get; set; }

          public string Video { get; set; }
     }
}
