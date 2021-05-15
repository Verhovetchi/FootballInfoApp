using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Infrastructure.Exceptions
{
     public class InvalidInputException : ApiException
     {
          public InvalidInputException(string message) : base(HttpStatusCode.BadRequest, message)
          {

          }
     }
}
