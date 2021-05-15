using FootballInfoApp.API.Infrastructure.Models.User;
using FootballInfoApp.Domain.Auth;
using AutoMapper;

namespace FootballInfoApp.API.Profiles
{
     public class UserProfile : Profile
     {
          public UserProfile()
          {
               CreateMap<User, UserLoginModel>();
               CreateMap<User, UserRegistrerModel>();
               CreateMap<User, UserModel>();
          }
     }
}
