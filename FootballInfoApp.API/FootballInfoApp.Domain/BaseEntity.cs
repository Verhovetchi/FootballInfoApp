using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.Domain
{
     public abstract class BaseEntity
     {
          [Key]
          public int Id { get; set; }
     }
}
