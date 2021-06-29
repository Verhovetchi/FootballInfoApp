using System;
using FootballInfoApp.Domain;
using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.API.Dtos.Coaches
{
     public class CoachDto
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

          public DateTime? BirthDate { get; set; }

          [Required]
          public string Photo { get; set; }

          public virtual Team Team { get; set; }
          public virtual Country Country { get; set; }
     }
}
