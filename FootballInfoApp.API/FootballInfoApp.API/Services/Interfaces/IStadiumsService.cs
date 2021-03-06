using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Interfaces
{
     public interface IStadiumsService
     {
          Task<Stadium> GetStadiumByTeamId(int TeamId);
          Task<ICollection<Stadium>> GetAllStadiums();
     }
}
