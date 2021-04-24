using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FootballInfoApp.API.Services.Interfaces;
using System.Linq;

namespace FootballInfoApp.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class SoccerController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly IPlayerService _playerService;

          public SoccerController(IMapper mapper, IPlayerService playerService, FootballInfoAppDbContext DB)
          {
               _mapper = mapper;
               _playerService = playerService;
          }

          [HttpGet("/values")]
          public string Get()
          {
               return "hello world";
          }
     }
}
