using FootballInfoApp.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;
using FootballInfoApp.API.Dtos.Players;

namespace FootballInfoApp.API.Services.Interfaces
{
     public interface IPlayerService
     {
          Task<ICollection<Player>> GetAllPlayers();
          Task<Player> GetPlayerById(int id);
          Task<Player> CreatePlayer(CreatePlayerDto playerDto);
          Task<Player> UpdatePlayerById(int id, UpdatePlayerDto playerDto);
          Task<Player> DeletePlayerById(int id);
     }
}
