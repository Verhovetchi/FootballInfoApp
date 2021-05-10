using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FootballInfoApp.Domain
{
     public class Match : BaseEntity
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
          [ForeignKey(nameof(HomeTeamId))]
          [InverseProperty("HomeMatches")]
          public virtual Team HomeTeam { get; set; }

          //[NotMapped]
          [ForeignKey(nameof(AwayTeamId))]
          [InverseProperty("AwayMatches")]
          public virtual Team AwayTeam { get; set; }

          public string Video { get; set; }
     }
}
