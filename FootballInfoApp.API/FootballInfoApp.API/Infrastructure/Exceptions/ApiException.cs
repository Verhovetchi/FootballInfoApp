using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Infrastructure.Exceptions
{
     public class ApiException : Exception
     {
          public HttpStatusCode Code { get; set; }
          public ApiException()
          {

          }

          public ApiException(HttpStatusCode code, string message) : base(message)
          {
               Code = code;
          }
     }
}
