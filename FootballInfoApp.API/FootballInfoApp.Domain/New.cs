using System;
using System.Collections.Generic;
using System.Text;

namespace FootballInfoApp.Domain
{
     public class New : BaseEntity
     {
          public string Title { get; set; }

          public string ShortDescription { get; set; }

          public string FullContent { get; set; }

          public string PicturePath { get; set; }
     }

     public class PageInfo
     {
          public int PageNumber { get; set; }
          public int PageSize { get; set; }
          public int TotalItems { get; set; }
          public int TotalPages
          {
               get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
          }
     }

     public class IndexViewModel
     {
          public IEnumerable<New> News { get; set; }
          public PageInfo PageInfo { get; set; }
          public int TotalNumbersOfItems { get; set; }
     }
}
