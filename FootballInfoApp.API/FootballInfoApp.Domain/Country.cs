using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.Domain
{
     public class Country : BaseEntity
     {
          [Required]
          [MaxLength(40)]
          public string Name { get; set; }

          public string FlagId { get; set; }

          public Flag Flag { get; set; }
     }
}
