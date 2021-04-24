using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.Domain
{
     public class Position : BaseEntity
     {
          [Required]
          [MaxLength(50)]
          public string Name { get; set; }

          public virtual ICollection<Player> Players { get; set; }
     }
}
