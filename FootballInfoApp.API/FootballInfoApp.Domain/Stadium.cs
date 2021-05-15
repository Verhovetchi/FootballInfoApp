using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

          [Required]
          public string StadiumImage { get; set; }

          [JsonIgnore]
          public virtual Team Team { get; set; }
     }
}
