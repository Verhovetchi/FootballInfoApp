using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FootballInfoApp.API.Services.Interfaces;

namespace FootballInfoApp.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class SoccerController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly IPlayerService _playerService;

          public SoccerController()
          {
               
          }

          [HttpGet("/values")]
          public string Get()
          {
               return "dkslaf";
          }
     }
}
