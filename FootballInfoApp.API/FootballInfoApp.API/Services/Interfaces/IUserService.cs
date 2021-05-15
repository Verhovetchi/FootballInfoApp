using FootballInfoApp.API.Infrastructure.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Services.Interfaces
{
     public interface IUserService
     {
          Task<string> Login(UserLoginModel userForLoginDto);
          Task SignUp(UserRegistrerModel userForLoginDto);
          UserModel GetUserWithRole();
     }
}
