using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Interfaces
{
     public interface ITeamService
     {
          Task<ICollection<Player>> GetAllPlayersFromTeam(int id);
          Task<ICollection<Player>> GetAllPlayersByPositionFromTeamId(int PositionId, int TeamId);
     }
}
