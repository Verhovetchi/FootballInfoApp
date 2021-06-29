using FootballInfoApp.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;
using FootballInfoApp.API.Dtos.Players;

namespace FootballInfoApp.API.Services.Interfaces
{
     public interface IPlayersService
     {
          Task<Player> GetPlayerById(int id);
          Task<ICollection<Player>> GetAllPlayers();
          Task<ICollection<Player>> GetAllPlayersFromTeam(int id);
          Task<Player> CreatePlayer(CreatePlayerDto playerDto);
          Task<Player> UpdatePlayerById(int id, UpdatePlayerDto playerDto);
          Task<bool> DeletePlayerById(int id);
     }
}
