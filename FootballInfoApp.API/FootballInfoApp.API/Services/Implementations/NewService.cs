using FootballInfoApp.API.Repositories.Interfaces;
using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Implementations
{
     public class NewService : INewService
     {
          private readonly IRepository _repository;

          public NewService(IRepository repository)
          {
               _repository = repository;
          }

          public async Task<ICollection<New>> GetAll()
          {
               return await _repository.GetAll<New>();
          }

          public async Task<New> GetNewById(int id)
          {
               var _new = await _repository.GetById<New>(id);

               return _new;
          }
     }
}
