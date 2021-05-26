using AutoMapper;
using FootballInfoApp.API.Dtos.News;
using FootballInfoApp.Domain;

namespace FootballInfoApp.API.Profiles
{
     public class NewProfile : Profile
     {
          public NewProfile()
          {
               CreateMap<New, NewDto>();
          }
     }
}
