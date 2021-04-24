using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballInfoApp.Domain
{
     public class Coach : BaseEntity
     {
          [Required]
          [MaxLength(25)]
          public string Name { get; set; }


          [Required]
          [MaxLength(25)]
          public string Surname { get; set; }

          [Required]
          public int CountryId { get; set; }

          [Required]
          public int TeamId { get; set; }

          public virtual Team Team { get; set; }
          public virtual Country Country { get; set; }
     }
}
