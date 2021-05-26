using FootballInfoApp.API.Dtos.News;
using FootballInfoApp.API.Repositories.Interfaces;
using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain;
using System.Collections.Generic;
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

          public async Task<New> CreateNew(CreateNewDto dto)
          {
               var _new = new New
               {
                    FullContent = dto.FullContent,
                    PicturePath = dto.PicturePath,
                    ShortDescription = dto.ShortDescription,
                    Title = dto.Title
               };

               _repository.Add(_new);

               await _repository.SaveAll();

               return _new;
          }

          public async Task<bool> DeleteNewById(int id)
          {
               var _new = await _repository.GetById<New>(id);

               if (_new == null)
                    return false;

               await _repository.Delete<New>(id);
               await _repository.SaveAll();

               return true;
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

          public async Task<New> UpdateNewById(int id, UpdateNewDto _new)
          {
               var _New = await _repository.GetById<New>(id);

               if (_New == null)
                    return null;

               if (!string.IsNullOrEmpty((_new.Title).ToString()))
                    _New.Title = _new.Title;

               if (!string.IsNullOrEmpty((_new.PicturePath).ToString()))
                    _New.PicturePath = _new.PicturePath;

               if (!string.IsNullOrEmpty((_new.ShortDescription).ToString()))
                    _New.ShortDescription = _new.ShortDescription;

               if (!string.IsNullOrEmpty((_new.FullContent).ToString()))
                    _New.FullContent = _new.FullContent;            

               _repository.Update(_New);
               await _repository.SaveAll();

               return _New;

          }
     }
}
