using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Dtos.News
{
     public class NewDto
     {
          public int Id { get; set; }

          public string Title { get; set; }

          public string ShortDescription { get; set; }

          public string FullContent { get; set; }

          public string PicturePath { get; set; }
     }
}
