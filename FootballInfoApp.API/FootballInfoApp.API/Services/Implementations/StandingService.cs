using FootballInfoApp.API.Repositories.Interfaces;
using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Implementations
{
     public class StandingService : IStandingService
     {
          private readonly IRepository _repository;

          public StandingService(IRepository repository)
          {
               _repository = repository;
          }

          async Task<ICollection<Standing>> IStandingService.Get()
          {
               var res = await _repository.GetAllWithInclude<Standing>(t => t.Team);

               return res;
          }
     }
}
