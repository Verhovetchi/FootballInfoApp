using System;
using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.Domain
{
     public class Player : BaseEntity
     {
          [Required]
          [MaxLength(50)]
          public string Name { get; set; }

          [Required]
          [MaxLength(50)]
          public string Surname { get; set; }

          [Required]
          public int PlayNumber { get; set; }

          [Required]
          public DateTime BirthDate { get; set; }

          [Required]
          public int Height { get; set; }

          [Required]
          public int Weight { get; set; }

          [Required]
          public int PositionId { get; set; }

          [Required]
          public int CountryId { get; set; }

          public int? TeamId { get; set; }

          public virtual Team Team { get; set; }
          public virtual Position Position { get; set; }
          public virtual Country Country { get; set; }

          public string Age(DateTime birthDate)
          {
               BirthDate = birthDate;
               DateTime now = DateTime.Now;

               int year = now.Year - BirthDate.Year;
               int month = now.Month - BirthDate.Month;
               int day = now.Day - BirthDate.Day;

               if ((month > 0) || (month == 0 && day >= 0))
                    return year.ToString();
               else
               {
                    year--;
                    return year.ToString();
               }
          }
     }
}
