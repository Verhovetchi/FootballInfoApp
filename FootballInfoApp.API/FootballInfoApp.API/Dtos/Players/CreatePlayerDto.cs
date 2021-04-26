using System;
using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.API.Dtos.Players
{
     public class CreatePlayerDto
     {
          [Required]
          [MinLength(2, ErrorMessage = "Name is too short!")]
          public string Name { get; set; }

          [Required]
          [MinLength(2, ErrorMessage = "Surname is too short!")]
          public string Surname { get; set; }

          [Required]
          [Range(1, 100, ErrorMessage = "Player number can't be negative and greater than 100!")]
          public int PlayNumber { get; set; }

          [Required]
          [DataType(DataType.DateTime, ErrorMessage = "Invalid format! (dd/mm/yyyy hh:mm)")]
          public DateTime BirthDate { get; set; }

          [Required]
          [Range(150, 220, ErrorMessage = "Height can't accept this value!")]
          public int Height { get; set; }

          [Required]
          [Range(50, 100, ErrorMessage = "Height can't accept this value!")]
          public int Weight { get; set; }

          [Required]
          public string Photo { get; set; }

          [Required]
          [Range(1, 4, ErrorMessage = "PositionId can't accept this value!")]
          public int PositionId { get; set; }

          [Required]
          [Range(0, 72, ErrorMessage = "CountryId can't accept this value!")]
          public int CountryId { get; set; }

          [Range(1, 20, ErrorMessage = "TeamId can't accept this value!")]
          public int? TeamId { get; set; }
     }
}
