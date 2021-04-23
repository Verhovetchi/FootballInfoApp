using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.Domain
{
     public class Logo : BaseEntity
     {
          [Required]
          public string Path { get; set; }
     }
}
