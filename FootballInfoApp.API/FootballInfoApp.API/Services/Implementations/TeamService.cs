using FootballInfoApp.API.Repositories.Interfaces;
using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Implementations
{
     public class TeamService : ITeamService
     {
          private readonly IRepository _repository;

          public TeamService(IRepository repository)
          {
               _repository = repository;
          }

          public async Task<ICollection<Player>> GetAllPlayersByPositionFromTeamId(int PositionId, int TeamId)
          {
               var players = await _repository.GetAllWithInclude<Player>(t => t.Team, c => c.Country, p => p.Position);

               var team = players.Where(t => t.TeamId == TeamId).ToList();

               var result = team.Where(p => p.PositionId == PositionId).ToList();

               return result;
          }

          public async Task<ICollection<Player>> GetAllPlayersFromTeam(int id)
          {
               var players = await _repository.GetAllWithInclude<Player>(t => t.Team, c => c.Country, p => p.Position);

               var result = players.Where(i => i.TeamId == id).ToList();

               return result;
          }

          public async Task<ICollection<Team>> GetAllTeams()
          {
               return await _repository.GetAllWithInclude<Team>(s => s.Stadium, c => c.Coaches, l=>l.League);
          }

          public async Task<ICollection<Coach>> GetCoach(int id)
          {
               return await _repository.GetAllWithInclude<Coach>(c => c.Country);
          }

     }
}
