using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FootballInfoApp.Domain
{
     public class Team : BaseEntity
     {
          public string Name { get; set; }
          public string LogoImage { get; set; }

          public int LeagueId { get; set; }
          public int StadiumId { get; set; }
          

          [JsonIgnore]
          public virtual ICollection<Coach> Coaches { get; set; }

          [JsonIgnore]
          public virtual ICollection<Player> Players { get; set; }

          [JsonIgnore]
          public virtual ICollection<Match> HomeMatches { get; set; }

          [JsonIgnore]
          public virtual ICollection<Match> AwayMatches { get; set; }

          public virtual League League { get; set; }

          public virtual Stadium Stadium { get; set; }
     }
}
