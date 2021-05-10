using FootballInfoApp.API.Repositories.Interfaces;
using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Implementations
{
     public class MatchService : IMatchService
     {
          private readonly IRepository _repository;

          public MatchService(IRepository repository)
          {
               _repository = repository;
          }

          public async Task<ICollection<Match>> GetAllMatches()
          {
               var matches = await _repository.GetAllWithInclude<Match>(h => h.AwayTeam, y => y.HomeTeam);

               return matches;
          }

          public async Task<Match> GetMatchById(int id)
          {
               var match = await _repository.GetAllWithInclude<Match>(h => h.AwayTeam, y => y.HomeTeam);

               var res = match.Where(i => i.Id == id).FirstOrDefault();

               return res;
          }

          public async Task<ICollection<Match>> GetMatchesByTeamId(int id)
          {
               return await _repository.GetAllWithInclude<Match>(h => h.HomeTeam, a => a.AwayTeam);
          }

          public async Task<Match> GetLastMatchByTeamId(int id)
          {
               var match = await _repository.GetAllWithInclude<Match>(h => h.AwayTeam, y => y.HomeTeam);

               var home = match.Where(i => i.HomeTeamId == id).Where(s => s.HomeTeamScored != null).OrderByDescending(d => d.MatchDate).FirstOrDefault();
               var away = match.Where(i => i.AwayTeamId == id).Where(s => s.HomeTeamScored != null).OrderByDescending(d => d.MatchDate).FirstOrDefault();

               if (home.MatchDate < away.MatchDate)
                    return away;
               else
                    return home;
          }

          public async Task<Match> GetNextMatchByTeamId(int id)
          {
               var match = await _repository.GetAllWithInclude<Match>(h => h.AwayTeam, y => y.HomeTeam);

               var home = match.Where(i => i.HomeTeamId == id).Where(s => s.HomeTeamScored == null).OrderBy(d => d.MatchDate).FirstOrDefault();
               var away = match.Where(i => i.AwayTeamId == id).Where(s => s.HomeTeamScored == null).OrderBy(d => d.MatchDate).FirstOrDefault();

               if (home.MatchDate > away.MatchDate)
                    return away;
               else
                    return home;
          }
     }
}
