using AutoMapper;
using FootballInfoApp.API.Dtos.Players;
using FootballInfoApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     [Authorize]
     public class TeamsController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly ITeamsService _teamService;

          public TeamsController(IMapper mapper, ITeamsService teamService)
          {
               _mapper = mapper;
               _teamService = teamService;
          }

          [HttpGet("/teams")]
          [AllowAnonymous]
          public async Task<IActionResult> Get()
          {
               var teams = await _teamService.GetAllTeams();

               return Ok(teams);
          }

          [HttpGet("/{TeamId}/players")]
          [AllowAnonymous]
          public async Task<IActionResult> Get(int TeamId)
          {
               var players = await _teamService.GetAllPlayersFromTeam(TeamId);

               if (players.Count == 0)
                    return NoContent();

               var playerDto = _mapper.Map<List<PlayerDto>>(players);
               return Ok(playerDto);
          }

          [HttpGet("/{TeamId}/{PositionId}")]
          [AllowAnonymous]
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
