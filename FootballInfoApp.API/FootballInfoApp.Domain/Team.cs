using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FootballInfoApp.Domain
{
     public class Team : BaseEntity
     {
          public string Name { get; set; }
          public string LogoImage { get; set; }

          public int LeagueId { get; set; }
          public int StadiumId { get; set; }

          public virtual Stadium Stadium { get; set; }
          public virtual League League { get; set; }

          [JsonIgnore]
          public virtual ICollection<Coach> Coaches { get; set; }

          [JsonIgnore]
          public virtual ICollection<Player> Players { get; set; }
          
          [JsonIgnore]
          [InverseProperty(nameof(Match.HomeTeam))]
          public virtual ICollection<Match> HomeMatches { get; set; }
          
          [JsonIgnore]
          [InverseProperty(nameof(Match.AwayTeam))]
          public virtual ICollection<Match> AwayMatches { get; set; }
     }
}
