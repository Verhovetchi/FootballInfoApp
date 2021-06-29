using FootballInfoApp.API.Dtos.Players;
using FootballInfoApp.API.Infrastructure.Exceptions;
using FootballInfoApp.API.Repositories.Interfaces;
using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Implementations
{
     public class PlayersService : IPlayersService
     {
          private readonly IRepository _repository;

          public PlayersService(IRepository repository)
          {
               _repository = repository;
          }
          
          public async Task<Player> GetPlayerById(int id)
          {
               var players = await _repository.GetAllWithInclude<Player>(c => c.Country, t => t.Team, p => p.Position);

               var player = players.Where(i => i.Id == id).FirstOrDefault();

               return player;
          }
          
          public async Task<ICollection<Player>> GetAllPlayers()
          {
               return await _repository.GetAllWithInclude<Player>(c => c.Country, t => t.Team, p => p.Position);
          }

          public async Task<ICollection<Player>> GetAllPlayersFromTeam(int id)
          {
               var result = await _repository.GetAllWithInclude<Player>(t => t.Team);
               
               var players = result.Where(i => i.TeamId == id);
               return players.ToList();
          }

          public async Task<Player> CreatePlayer(CreatePlayerDto playerDto)
          {
               if (await CheckIfPlayerNumberExists(playerDto.TeamId, playerDto.PlayNumber))
               {
                    throw new EntryAlreadyExistsException("A player with this play number already exists!!!");
               }

               var newPlayer = new Player
               {
                    BirthDate = playerDto.BirthDate,
                    CountryId = playerDto.CountryId,
                    Height = playerDto.Height,
                    Name = playerDto.Name,
                    Photo = playerDto.Photo,
                    PlayNumber = playerDto.PlayNumber,
                    PositionId = playerDto.PositionId,
                    Surname = playerDto.Surname,
                    TeamId = playerDto.TeamId,
                    Weight = playerDto.Weight
               };

               _repository.Add(newPlayer);
               await _repository.SaveAll();

               return newPlayer;
          }

          private async Task<bool> CheckIfPlayerNumberExists(int? teamId, int playNumber)
          {
               if (teamId.HasValue)
               {
                    var player = await GetAllPlayersFromTeam(teamId.Value);
                    bool flag = player.Any(x => x.PlayNumber == playNumber);
                    return flag;
               }

               return true;

          }

          public async Task<bool> DeletePlayerById(int id)
          {
               var player = await _repository.GetById<Player>(id);

               if (player == null)
                    return false;

               await _repository.Delete<Player>(id);
               await _repository.SaveAll();

               return true;
          }



          public async Task<Player> UpdatePlayerById(int id, UpdatePlayerDto playerDto)
          {
               var player = await _repository.GetById<Player>(id);

               if (player == null)
                    return null;

               if (!string.IsNullOrEmpty((playerDto.BirthDate).ToString()))
                    player.BirthDate = playerDto.BirthDate;

               if (!string.IsNullOrEmpty((playerDto.CountryId).ToString()))
                    player.CountryId = playerDto.CountryId;

               if (!string.IsNullOrEmpty((playerDto.Height).ToString()))
                    player.Height = playerDto.Height;

               if (!string.IsNullOrEmpty((playerDto.Name).ToString()))
                    player.Name = playerDto.Name;

               if (!string.IsNullOrEmpty((playerDto.Photo).ToString()))
                    player.Photo = playerDto.Photo;

               if (!string.IsNullOrEmpty((playerDto.PlayNumber).ToString()))
                    player.PlayNumber = playerDto.PlayNumber;

               if (!string.IsNullOrEmpty((playerDto.PositionId).ToString()))
                    player.PositionId = playerDto.PositionId;

               if (!string.IsNullOrEmpty((playerDto.Surname).ToString()))
                    player.Surname = playerDto.Surname;

               if (!string.IsNullOrEmpty((playerDto.TeamId).ToString()))
                    player.TeamId = playerDto.TeamId;

               if (!string.IsNullOrEmpty((playerDto.Weight).ToString()))
                    player.Weight = playerDto.Weight;


               _repository.Update(player);
               await _repository.SaveAll();

               return player;

          }
     }
}
