using AutoMapper;
using FootballInfoApp.API.Dtos.Stadiums;
using FootballInfoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Profiles
{
     public class StadiumProfile : Profile
     {
          public StadiumProfile()
          {
               CreateMap<Stadium, StadiumDto>();
          }
     }
}
