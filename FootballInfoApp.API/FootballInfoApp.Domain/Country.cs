using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.Domain
{
     public class Country : BaseEntity
     {
          [Required]
          [MaxLength(40)]
          public string Name { get; set; }

          public string FlagImage { get; set; }

          public ICollection<Player> Players { get; set; }
          public ICollection<Coach> Coaches { get; set; }
          public ICollection<League> Leagues { get; set; }
     }
}
