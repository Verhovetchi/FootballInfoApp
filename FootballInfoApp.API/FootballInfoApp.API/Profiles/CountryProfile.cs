using AutoMapper;
using FootballInfoApp.Domain;
using FootballInfoApp.API.Dtos.Countries;

namespace FootballInfoApp.API.Profiles
{
     public class CountryProfile : Profile
     {
          public CountryProfile()
          {
               CreateMap<Country, CountryDto>();
          }
     }
}
