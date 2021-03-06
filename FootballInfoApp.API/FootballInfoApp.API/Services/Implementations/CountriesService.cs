using FootballInfoApp.API.Repositories.Interfaces;
using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Implementations
{
     public class CountriesService : ICountriesService
     {
          private readonly IRepository _repository;

          public CountriesService(IRepository repository)
          {
               _repository = repository;
          }

          public async Task<ICollection<Country>> GetAll()
          {
               return await _repository.GetAll<Country>();
          }
     }
}
