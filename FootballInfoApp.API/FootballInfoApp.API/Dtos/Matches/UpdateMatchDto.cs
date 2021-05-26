using System;
using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.API.Dtos.Matches
{
     public class UpdateMatchDto
     {
          //[Range(0, 100, ErrorMessage = "Value must be between 0 and 100")]
          //public int Tour { get; set; }

          public int HomeTeamId { get; set; }

          public int AwayTeamId { get; set; }

          public int? HomeTeamScored { get; set; }

          public int? AwayTeamScored { get; set; }

          //[DataType(DataType.Date, ErrorMessage = "Invalid date")]
          //public DateTime? MatchDate { get; set; }

          //public int StadiumId { get; set; }

          public string Video { get; set; }
     }
}
