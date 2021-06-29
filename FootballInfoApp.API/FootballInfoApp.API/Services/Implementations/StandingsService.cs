using FootballInfoApp.API.Repositories.Interfaces;
using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Implementations
{
     public class StandingsService : IStandingsService
     {
          private readonly IRepository _repository;

          public StandingsService(IRepository repository)
          {
               _repository = repository;
          }

          public async Task<Standing> GetTeam(int teamId)
          {
               return await _repository.GetById<Standing>(teamId);
          }

          async Task<ICollection<Standing>> IStandingsService.Get()
          {
               var res = await _repository.GetAllWithInclude<Standing>(t => t.Team);
               var result = res.OrderByDescending(p=>p.Points).ToList();

               return result;
          }

          
     }
}
