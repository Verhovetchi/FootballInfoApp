using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballInfoApp.Domain
{
     public class Team : BaseEntity
     {
          public string Name { get; set; }
          public string LogoImage { get; set; }

          public int LeagueId { get; set; }
          public int StadiumId { get; set; }

          public virtual Stadium Stadium { get; set; }

          public virtual ICollection<Coach> Coaches { get; set; }
          public virtual ICollection<Player> Players { get; set; }
          public virtual ICollection<Match> HomeMatches { get; set; }
          public virtual ICollection<Match> AwayMatches { get; set; }
     }
}
