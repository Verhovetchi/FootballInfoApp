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
     public class PlayerController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly IPlayersService _playerService;

          public PlayerController(IMapper mapper, IPlayersService playerService)
          {
               _mapper = mapper;
               _playerService = playerService;
          }

          [HttpGet("/players/{id}")]
          [AllowAnonymous]
          public async Task<IActionResult> Get(int id)
          {
               var player = await _playerService.GetPlayerById(id);

               if (player == null)
                    return NotFound();

               var playerDto = _mapper.Map<PlayerDto>(player);

               return Ok(playerDto);

          }

          [HttpGet("/players")]
          //[Authorize(Roles = "Admin")]
          public async Task<IActionResult> Get()
          {
               var players = await _playerService.GetAllPlayers();
               var playerDto = _mapper.Map<List<PlayerDto>>(players);
               return Ok(playerDto);
          }

          [HttpPost("/players")]
          [Authorize(Roles = "Admin")]
          public async Task<IActionResult> Add([FromBody] CreatePlayerDto dto)
          {
               var player = await _playerService.CreatePlayer(dto);

               if (player == null)
                    return BadRequest("Player with such number in this team already exists!");

               var result = _mapper.Map<PlayerDto>(player);

               return Ok(result);
          }


          [HttpDelete("/players/{id}")]
          [Authorize(Roles = "Admin")]
          public async Task<IActionResult> Delete(int id)
          {
               await _playerService.DeletePlayerById(id);
               return NoContent();
          }

          [HttpPatch("/players/{id}")]
          [Authorize(Roles = "Admin")]
          public async Task<IActionResult> Patch(int id, [FromBody] UpdatePlayerDto updatedPlayer)
          {
               var player = await _playerService.UpdatePlayerById(id, updatedPlayer);

               var result = _mapper.Map<PlayerDto>(player);

               return Ok(result);
          }

     }
}
