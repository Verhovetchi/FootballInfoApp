using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Interfaces
{
     public interface ICountriesService
     {
          Task<ICollection<Country>> GetAll();
     }
}
