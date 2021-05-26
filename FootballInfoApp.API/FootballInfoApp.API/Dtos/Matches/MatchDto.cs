using FootballInfoApp.Domain;
using System;

namespace FootballInfoApp.API.Dtos.Matches
{
     public class MatchDto
     {
          public int Id { get; set; }

          public int Tour { get; set; }

          public int? HomeTeamScored { get; set; }

          public int? AwayTeamScored { get; set; }

          public DateTime? MatchDate { get; set; }

          public int StadiumId { get; set; }

          public virtual League League { get; set; }
          
          public virtual Team HomeTeam { get; set; }

          public virtual Team AwayTeam { get; set; }

          public string Video { get; set; }
     }
}
