using AutoMapper;
using FootballInfoApp.API.Infrastructure.Exceptions;
using FootballInfoApp.API.Infrastructure.Models.User;
using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Controllers.Auth
{
     [Route("api/[controller]")]
     [ApiController]
     public class UserController : ControllerBase
     {
          public readonly IUserService _userService;
          private readonly IMapper _mapper;
          private readonly UserManager<User> _userManager;

          public UserController(IUserService userService, IMapper mapper, UserManager<User> userManager)
          {
               _userService = userService;
               _mapper = mapper;
               _userManager = userManager;
               
          }

          [AllowAnonymous]
          [ApiExceptionFilter]
          [HttpPost("/login")]
          public async Task<IActionResult> Login(UserLoginModel userForLoginDto)
          {
               var accessToken = await _userService.Login(userForLoginDto);

               if (accessToken == null)
               {
                    return Unauthorized();
               }

               return Ok(new { AccessToken = accessToken });
          }

          [AllowAnonymous]
          [ApiExceptionFilter]
          [HttpPost("/register")]
          public async Task<IActionResult> Register(UserRegistrerModel userModel)
          {
               await _userService.SignUp(userModel);

               return Ok();
          }
          
          [HttpGet("/user")]
          public IActionResult GetAccount()
          {
               var account = _userService.GetUserWithRole();

               var accountDto = _mapper.Map<UserModel>(account);

               return Ok(accountDto);
          }

          [HttpGet("/role")]
          public IActionResult GetRole()
          {
               string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
               return Ok(new { Role = role });
          }

          [HttpGet("/isAuth")]
          [AllowAnonymous]
          public bool IsAuth()
          {
               bool isAuth = User.Identity.IsAuthenticated;
               return isAuth;
          }

          [HttpGet("/allUsers")]
          [AllowAnonymous]
          public IActionResult Users()
          {
               var res = _userManager.Users.ToList();
               return Ok(res);
          }
     }
}
