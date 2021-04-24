using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FootballInfoApp.API.Services.Interfaces;
using System.Linq;
using System.Collections;

namespace FootballInfoApp.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class SoccerController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly IPlayerService _playerService;
          private readonly FootballInfoAppDbContext _db;

          public SoccerController(IMapper mapper, IPlayerService playerService, FootballInfoAppDbContext DB)
          {
               _db = DB;
               _mapper = mapper;
               _playerService = playerService;
          }

          [HttpGet("/values")]
          public ICollection Get()
          {
               var positions = _db.Positions.ToList();
               return positions;
          }
     }
}
