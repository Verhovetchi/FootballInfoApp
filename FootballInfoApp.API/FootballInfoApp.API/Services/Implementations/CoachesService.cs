using FootballInfoApp.API.Repositories.Interfaces;
using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Implementations
{
     public class CoachesService : ICoachesService
     {
          private readonly IRepository _repository;

          public CoachesService(IRepository repository)
          {
               _repository = repository;
          }

          //public async Task<Player> GetPlayerById(int id)
          //{
          //     var players = await _repository.GetAllWithInclude<Player>(c => c.Country, t => t.Team, p => p.Position);

          //     var player = players.Where(i => i.Id == id).FirstOrDefault();

          //     return player;
          //}

          public async Task<Coach> GetCoachById(int id)
          {
               var coaches = await _repository.GetAllWithInclude<Coach>(c => c.Country, t => t.Team);

               var coach = coaches.Where(i => i.Id == id).FirstOrDefault();

               return coach;
          }
     }
}
