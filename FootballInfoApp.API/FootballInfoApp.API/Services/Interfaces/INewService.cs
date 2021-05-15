using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Interfaces
{
     public interface INewService
     {
          Task<New> GetNewById(int id);
          Task<ICollection<New>> GetAll();
          //Task<New> CreateNew(New _new);
          //Task<New> UpdateNewById(int id, New _new);
          //Task<bool> DeletePlayerById(int id);
     }
}
