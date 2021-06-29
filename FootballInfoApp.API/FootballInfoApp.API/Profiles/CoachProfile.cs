using AutoMapper;
using FootballInfoApp.Domain;
using FootballInfoApp.API.Dtos.Coaches;

namespace FootballInfoApp.API.Profiles
{
     public class CoachProfile : Profile
     {
          public CoachProfile()
          {
               CreateMap<Coach, CoachDto>();
          }
     }
}
