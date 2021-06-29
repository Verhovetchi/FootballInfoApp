using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Interfaces
{
     public interface ITeamsService
     {
          Task<ICollection<Team>> GetAllTeams();
          Task<ICollection<Player>> GetAllPlayersFromTeam(int id);
          Task<ICollection<Player>> GetAllPlayersByPositionFromTeamId(int PositionId, int TeamId);
     }
}
