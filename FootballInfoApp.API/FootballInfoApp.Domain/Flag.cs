using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.Domain
{
     public class Flag : BaseEntity
     {
          [Required]
          public string ImagePath { get; set; }
     }
}
