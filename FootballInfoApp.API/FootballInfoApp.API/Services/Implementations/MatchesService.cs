using FootballInfoApp.API.Dtos.Matches;
using FootballInfoApp.API.Repositories.Interfaces;
using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Implementations
{
     public class MatchesService : IMatchesService
     {
          private readonly IRepository _repository;
          private readonly IStandingsService _standing;

          public MatchesService(IRepository repository, IStandingsService standing)
          {
               _repository = repository;
               _standing = standing;
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

          public async Task<Match> CreateMatch(CreateMatchDto matchDto)
          {
               var match = new Match
               {
                    AwayTeamId = matchDto.AwayTeamId,
                    HomeTeamId = matchDto.HomeTeamId,
                    MatchDate = matchDto.MatchDate,
                    StadiumId = matchDto.StadiumId,
                    Tour = matchDto.Tour,
                    LeagueId = 9,
               };

               _repository.Add(match);

               await _repository.SaveAll();

               return match;
          }

          public async Task<Match> UpdateMatchById(int id, UpdateMatchDto matchDto)
          {
               var match = await _repository.GetById<Match>(id);

               if (match == null)
                    return null;

               if (!string.IsNullOrEmpty((matchDto.HomeTeamId).ToString()))
                    match.HomeTeamId = matchDto.HomeTeamId;

               if (!string.IsNullOrEmpty((matchDto.AwayTeamId).ToString()))
                    match.AwayTeamId = matchDto.AwayTeamId;

               if (!string.IsNullOrEmpty((matchDto.HomeTeamScored).ToString()))
                    match.HomeTeamScored = matchDto.HomeTeamScored;

               if (!string.IsNullOrEmpty((matchDto.AwayTeamScored).ToString()))
                    match.AwayTeamScored = matchDto.AwayTeamScored;

               if (!string.IsNullOrEmpty((matchDto.Video)))
                    match.Video = matchDto.Video;


               var homeTeam = await _standing.GetTeam(matchDto.HomeTeamId);
               var awayTeam = await _standing.GetTeam(matchDto.AwayTeamId);

               homeTeam.NumberOfMatches++;
               awayTeam.NumberOfMatches++;
               homeTeam.GoalsScored += (int)matchDto.HomeTeamScored;
               homeTeam.GoalsReceived += (int)matchDto.AwayTeamScored;
               awayTeam.GoalsScored += (int)matchDto.AwayTeamScored;
               awayTeam.GoalsReceived += (int)matchDto.HomeTeamScored;

               if (matchDto.HomeTeamScored > matchDto.AwayTeamScored)
               {
                    homeTeam.Wins++;
                    awayTeam.Loses++;
                    homeTeam.Points += 3;
               }
               else if(matchDto.HomeTeamScored < matchDto.AwayTeamScored)
               {
                    homeTeam.Loses++;
                    awayTeam.Wins++;
                    awayTeam.Points += 3;
               }
               else
               {
                    homeTeam.Draws++;
                    awayTeam.Draws++;
                    homeTeam.Points += 1;
                    awayTeam.Points += 1;
               }

               _repository.Update(match);
               await _repository.SaveAll();

               return match;
          }

          public Task<bool> DeleteMatchById(int id)
          {
               throw new NotImplementedException();
          }

          public async Task<ICollection<Match>> GetAllNonPlayedMatches()
          {
               var res = await _repository.GetAllWithInclude<Match>(h => h.HomeTeam, a => a.AwayTeam);
               var matches = res.Where(h => h.HomeTeamScored == null).Where(a => a.AwayTeamScored == null).ToList();

               return matches;
          }
     }
}
