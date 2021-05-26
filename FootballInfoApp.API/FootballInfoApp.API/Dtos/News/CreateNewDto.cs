using System.ComponentModel.DataAnnotations;

namespace FootballInfoApp.API.Dtos.News
{
     public class CreateNewDto
     {
          [Required]
          public string Title { get; set; }

          [Required]
          public string ShortDescription { get; set; }

          [Required]
          public string FullContent { get; set; }

          [Required]
          public string PicturePath { get; set; }
     }
}
