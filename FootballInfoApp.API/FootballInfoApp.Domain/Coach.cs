using System.ComponentModel.DataAnnotations;

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

          public int TeamId { get; set; }

          [Required]
          public int CountryId { get; set; }

          public Country Country { get; set; }
          public Team Team { get; set; }
     }
}
