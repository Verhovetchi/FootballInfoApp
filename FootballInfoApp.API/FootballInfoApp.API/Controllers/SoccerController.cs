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
     public class SoccerController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly IPlayerService _playerService;

          public SoccerController(IMapper mapper, IPlayerService playerService)
          {
               _mapper = mapper;
               _playerService = playerService;
          }

          [HttpGet("/player/{id}")]
          public async Task<IActionResult> GetPlayerById(int id)
          {
               var player = await _playerService.GetPlayerById(id);

               if (player == null)
                    return NotFound();

               var playerDto = _mapper.Map<PlayerDto>(player);

               return Ok(playerDto);

          }

          [HttpGet("/players")]
          public async Task<IActionResult> GetPlayers()
          {
               var players = await _playerService.GetAllPlayers();
               var playerDto = _mapper.Map<List<PlayerDto>>(players);
               return Ok(playerDto);
          }

          [HttpGet("/playersByTeamId/{id}")]
          public async Task<IActionResult> GetAllFromTeam(int id)
          {
               var players = await _playerService.GetAllPlayersFromTeam(id);

               if (players.Count == 0)
                    return NoContent();

               var playerDto = _mapper.Map<List<PlayerDto>>(players);
               return Ok(playerDto);
          }

          [HttpPost("/createPlayer")]
          public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerDto dto)
          {
               var player = await _playerService.CreatePlayer(dto);

               if (player == null)
                    return BadRequest("Player with such number in this team already exists!");

               var result = _mapper.Map<PlayerDto>(player);

               return Ok(result);
          }


          [HttpDelete("/deletePlayer/{id}")]
          public async Task<IActionResult> DeletePlayer(int id)
          {
               await _playerService.DeletePlayerById(id);
               return NoContent();
          }

          [HttpPatch("{id}")]
          public async Task<IActionResult> UpdatePlayer(int id, [FromBody] UpdatePlayerDto updatedPlayer)
          {
               var player = await _playerService.UpdatePlayerById(id, updatedPlayer);

               var result = _mapper.Map<PlayerDto>(player);

               return Ok(result);
          }

     }
}
