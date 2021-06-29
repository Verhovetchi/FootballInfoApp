using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Interfaces
{
     public interface IStandingsService
     {
          Task<ICollection<Standing>> Get();

          Task<Standing> GetTeam(int teamId);
     }
}
