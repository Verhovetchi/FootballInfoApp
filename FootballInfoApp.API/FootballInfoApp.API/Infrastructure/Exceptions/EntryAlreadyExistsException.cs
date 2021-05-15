using System.Net;

namespace FootballInfoApp.API.Infrastructure.Exceptions
{
     public class EntryAlreadyExistsException : ApiException
     {
          public EntryAlreadyExistsException(string message) : base(HttpStatusCode.BadRequest, message)
          {

          }
     }
}
