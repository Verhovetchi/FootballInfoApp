using System;
using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.Domain
{
     public class Stadium : BaseEntity
     {
          [Required]
          [MaxLength(100)]
          public string Name { get; set; }

          [Required]
          public int Capacity { get; set; }

          [Required]
          public DateTime MadeDate { get; set; }

     }
}
