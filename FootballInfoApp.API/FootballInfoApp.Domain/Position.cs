using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FootballInfoApp.Domain
{
     public class Position : BaseEntity
     {
          [Required]
          [MaxLength(50)]
          public string Name { get; set; }

          [JsonIgnore]
          public ICollection<Player> Players { get; set; }
     }
}
