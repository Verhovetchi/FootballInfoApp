using System;
using FootballInfoApp.Domain;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.API.Dtos.Stadiums
{
     public class StadiumDto
     {
          [Required]
          [MaxLength(100)]
          public string Name { get; set; }

          [Required]
          public int Capacity { get; set; }

          [Required]
          public DateTime MadeDate { get; set; }

          [Required]
          public string StadiumImage { get; set; }

          [JsonIgnore]
          public virtual Team Team { get; set; }
     }
}
