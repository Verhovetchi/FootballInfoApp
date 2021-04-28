using AutoMapper;
using FootballInfoApp.API.Dtos.Players;
using FootballInfoApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class TeamController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly ITeamService _teamService;

          public TeamController(IMapper mapper, ITeamService teamService)
          {
               _mapper = mapper;
               _teamService = teamService;
          }

          [HttpGet("/{TeamId}/players")]
          public async Task<IActionResult> Get(int TeamId)
          {
               var players = await _teamService.GetAllPlayersFromTeam(TeamId);

               if (players.Count == 0)
                    return NoContent();

               var playerDto = _mapper.Map<List<PlayerDto>>(players);
               return Ok(playerDto);
          }

          [HttpGet("/{TeamId}/{PositionId}/players")]
          public async Task<IActionResult> Get(int TeamId, int PositionId)
          {
               var players = await _teamService.GetAllPlayersByPositionFromTeamId(PositionId, TeamId);

               if (players.Count == 0)
                    return NoContent();

               var playerDto = _mapper.Map<List<PlayerDto>>(players);
               return Ok(playerDto);
          }


     }
}
