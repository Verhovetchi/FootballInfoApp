using FootballInfoApp.API.Repositories.Interfaces;
using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Implementations
{
     public class StadiumService : IStadiumService
     {
          private readonly IRepository _repository;

          public StadiumService(IRepository repository)
          {
               _repository = repository;
          }

          public Task<Stadium> GetStadiumByTeamId(int TeamId)
          {
               var stadium = _repository.GetById<Stadium>(TeamId);
               return stadium;
          }
     }
}
