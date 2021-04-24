using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.Domain
{
     public class League : BaseEntity
     {
          [Required]
          [MaxLength(100)]
          public string Name { get; set; }

          public int CountryId { get; set; }

          public virtual Country Country { get; set; }

          public virtual ICollection<Match> Matches { get; set; }
     }
}
