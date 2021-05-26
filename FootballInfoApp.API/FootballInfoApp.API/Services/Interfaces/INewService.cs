using FootballInfoApp.API.Dtos.News;
using FootballInfoApp.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Interfaces
{
     public interface INewService
     {
          Task<New> GetNewById(int id);
          Task<ICollection<New>> GetAll();
          Task<New> CreateNew(CreateNewDto _new);
          Task<New> UpdateNewById(int id, UpdateNewDto _new);
          Task<bool> DeleteNewById(int id);
     }
}
