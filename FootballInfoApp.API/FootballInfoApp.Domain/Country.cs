using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FootballInfoApp.Domain
{
     public class Country : BaseEntity
     {
          [Required]
          [MaxLength(40)]
          public string Name { get; set; }

          public string FlagImage { get; set; }

          [JsonIgnore]
          public ICollection<Player> Players { get; set; }

          [JsonIgnore]
          public ICollection<Coach> Coaches { get; set; }

          [JsonIgnore]
          public ICollection<League> Leagues { get; set; }
     }
}
