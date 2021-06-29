using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FootballInfoApp.API.Services.Interfaces;
using AutoMapper;
using FootballInfoApp.API.Dtos.Coaches;

namespace FootballInfoApp.API.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class CoachesController : ControllerBase
     {
          private readonly ICoachesService _coachService;
          private readonly IMapper _mapper;

          public CoachesController(ICoachesService coachService, IMapper mapper)
          {
               _coachService = coachService;
               _mapper = mapper;
          }

          [HttpGet("{id}")]
          [AllowAnonymous]
          public async Task<IActionResult> Get(int id)
          {
               var coach = await _coachService.GetCoachById(id);

               if (coach == null)
                    return NotFound();

               var coachDto = _mapper.Map<CoachDto>(coach);

               return Ok(coachDto);

          }
     }
}
