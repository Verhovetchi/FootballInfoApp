using AutoMapper;
using FootballInfoApp.Domain;
using FootballInfoApp.API.Dtos.Players;

namespace FootballInfoApp.API.Profiles
{
     public class PlayerProfile : Profile
     {
          public PlayerProfile()
          {
               CreateMap<Player, PlayerDto>();
          }
     }
}
