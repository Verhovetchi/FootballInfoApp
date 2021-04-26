using System;
using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.API.Dtos.Players
{
     public class UpdatePlayerDto
     {
          [MinLength(2, ErrorMessage = "Name is too short!")]
          public string Name { get; set; }

          [MinLength(2, ErrorMessage = "Surname is too short!")]
          public string Surname { get; set; }

          [Range(1, 100, ErrorMessage = "Player number can't be negative and greater than 100!")]
          public int PlayNumber { get; set; }

          [DataType(DataType.DateTime, ErrorMessage = "Invalid format! (dd/mm/yyyy hh:mm)")]
          public DateTime BirthDate { get; set; }

          [Range(150, 220, ErrorMessage = "Height can't accept this value!")]
          public int Height { get; set; }

          [Range(50, 100, ErrorMessage = "Height can't accept this value!")]
          public int Weight { get; set; }

          public string Photo { get; set; }

          [Range(1, 4, ErrorMessage = "PositionId can't accept this value!")]
          public int PositionId { get; set; }

          [Range(0, 72, ErrorMessage = "CountryId can't accept this value!")]
          public int CountryId { get; set; }

          [Range(1, 20, ErrorMessage = "TeamId can't accept this value!")]
          public int? TeamId { get; set; }
     }
}
