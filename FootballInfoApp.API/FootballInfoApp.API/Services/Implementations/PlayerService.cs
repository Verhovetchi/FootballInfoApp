using FootballInfoApp.API.Dtos.Players;
using FootballInfoApp.API.Repositories.Interfaces;
using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Implementations
{
     public class PlayerService : IPlayerService
     {
          private readonly IRepository _repository;

          public PlayerService(IRepository repository)
          {
               _repository = repository;
          }

          public Task<Player> CreatePlayer(CreatePlayerDto playerDto)
          {
               throw new NotImplementedException();
          }

          public Task<Player> DeletePlayerById(int id)
          {
               throw new NotImplementedException();
          }

          public Task<ICollection<Player>> GetAllPlayers()
          {
               throw new NotImplementedException();
          }

          public Task<Player> GetPlayerById(int id)
          {
               throw new NotImplementedException();
          }

          public Task<Player> UpdatePlayerById(int id, UpdatePlayerDto playerDto)
          {
               throw new NotImplementedException();
          }
     }
}
