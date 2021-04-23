using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.Domain
{
     public class League : BaseEntity
     {
          [Required]
          [MaxLength(100)]
          public string Name { get; set; }

          public int CountryId { get; set; }

          public Country Country { get; set; }
     }
}
