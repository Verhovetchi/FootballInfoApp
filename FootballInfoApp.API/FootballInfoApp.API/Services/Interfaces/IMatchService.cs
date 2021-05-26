using FootballInfoApp.API.Dtos.Matches;
using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Interfaces
{
     public interface IMatchService
     {
          Task<Match> GetMatchById(int id);
          Task<Match> GetLastMatchByTeamId(int id);
          Task<Match> GetNextMatchByTeamId(int id);
          Task<ICollection<Match>> GetAllMatches();
          Task<ICollection<Match>> GetAllNonPlayedMatches();
          Task<ICollection<Match>> GetMatchesByTeamId(int id);
          Task<Match> CreateMatch(CreateMatchDto matchDto);
          Task<Match> UpdateMatchById(int id, UpdateMatchDto matchDto);
          Task<bool> DeleteMatchById(int id);
          //Task<ICollection<Match>> GetAllMatchesByTeamId(int id);
          //Task<ICollection<Match>> GetLastFiveMatchesByTeamId(int teamId, int numberOfMatches);
     }
}
