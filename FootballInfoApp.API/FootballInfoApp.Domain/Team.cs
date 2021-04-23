using System.Collections.Generic;

namespace FootballInfoApp.Domain
{
     public class Team : BaseEntity
     {
          public string Name { get; set; }
          public int LeagueId { get; set; }
          public int MyProperty { get; set; }
          public int LogoId { get; set; }
          public int StadiumId { get; set; }

          public Logo Logo { get; set; }
          public Stadium Stadium { get; set; }

          public virtual ICollection<Player> Players { get; set; }
     }
}
