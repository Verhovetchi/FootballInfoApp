using AutoMapper;
using FootballInfoApp.API.Dtos.Matches;
using FootballInfoApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class MatchesController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly IMatchesService _matchService;

          public MatchesController(IMapper mapper, IMatchesService matchService)
          {
               _mapper = mapper;
               _matchService = matchService;
          }

          [AllowAnonymous]
          [HttpGet("{id}")]
          public async Task<MatchDto> GetMatchById(int id)
          {
               var match = await _matchService.GetMatchById(id);

               var matchDto = _mapper.Map<MatchDto>(match);

               return matchDto;
          }

          [AllowAnonymous]
          [HttpGet("/last/{id}")]
          public async Task<IActionResult> GetLastMatchByTeamId(int id)
          {
               var matches = await _matchService.GetLastMatchByTeamId(id);
               return Ok(matches);
          }

          [HttpGet("/next/{id}")]
          [AllowAnonymous]
          public async Task<IActionResult> GetNextMatchByTeamId(int id)
          {
               var matches = await _matchService.GetNextMatchByTeamId(id);

               return Ok(matches);
          }

          [HttpGet("/matches/{TeamId}/{flag}")]
          [AllowAnonymous]
          public async Task<IActionResult> GetMatchesByTeamId(int TeamId, string flag)
          {
               var matches = await _matchService.GetAllMatches();

               var home = matches.Where(t => t.HomeTeamId == TeamId);
               var away = matches.Where(t => t.AwayTeamId == TeamId);

               switch (flag)
               {
                    case "calendar":
                         return Ok(home.Concat(away).OrderBy(x => x.Tour));
                    case "results":
                         return Ok(home.Concat(away).OrderBy(x => x.Tour).Where(s => s.HomeTeamScored != null));
                    default:
                         return NotFound();
               }

          }

          [HttpGet("/form/{id}")]
          [AllowAnonymous]
          public async Task<IActionResult> GetForm(int id)
          {
               var matches = await _matchService.GetMatchesByTeamId(id);

               var home = matches.Where(t => t.HomeTeamId == id);
               var away = matches.Where(t => t.AwayTeamId == id);

               var result = home.Concat(away).OrderByDescending(d => d.MatchDate).Where(g => g.HomeTeamScored != null).Take(5);

               return Ok(result);
          }

          [HttpGet("/matches")]
          [Authorize(Roles = "Admin")]
          public async Task<IActionResult> GetAllMatches()
          {
               var matches = await _matchService.GetAllMatches();

               return Ok(matches);
          }

          [HttpGet("/nonPlayedMatches")]
          [Authorize(Roles = "Admin")]
          public async Task<IActionResult> GetAllNonPlayedGames()
          {
               var matches = await _matchService.GetAllNonPlayedMatches();

               return Ok(matches.ToList());
          }

          [HttpPost("/matches")]
          [Authorize(Roles = "Admin")]
          public async Task<IActionResult> Add([FromBody] CreateMatchDto dto)
          {
               var match = await _matchService.CreateMatch(dto);

               _mapper.Map<MatchDto>(match);

               return Ok(match);
          }

          [HttpPatch("{id}")]
          [Authorize(Roles = "Admin")]
          public async Task<IActionResult> Patch(int id, [FromBody] UpdateMatchDto updatedMatch)
          {
               var match = await _matchService.UpdateMatchById(id, updatedMatch);

               var result = _mapper.Map<MatchDto>(match);

               return Ok(result);
          }
     }
}
