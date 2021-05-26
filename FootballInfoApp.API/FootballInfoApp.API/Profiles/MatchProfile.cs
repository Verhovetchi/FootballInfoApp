using AutoMapper;
using FootballInfoApp.API.Dtos.Matches;
using FootballInfoApp.Domain;

namespace FootballInfoApp.API.Profiles
{
     public class MatchProfile : Profile
     {
          public MatchProfile()
          {
               CreateMap<Match, MatchDto>();
               CreateMap<Match, CreateMatchDto>();
          }
     }
}
