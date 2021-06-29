using FootballInfoApp.Domain;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.API.Dtos.Countries
{
     public class CountryDto
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
