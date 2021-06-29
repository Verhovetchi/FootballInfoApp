using AutoMapper;
using FootballInfoApp.API.Dtos.Standings;
using FootballInfoApp.Domain;

namespace FootballInfoApp.API.Profiles
{
     public class StandingProfile : Profile
     {
          public StandingProfile()
          {
               CreateMap<Standing, StandingDto>();
          }
     }
}
