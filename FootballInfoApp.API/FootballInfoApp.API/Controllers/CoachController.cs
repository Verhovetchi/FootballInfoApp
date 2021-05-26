using AutoMapper;
using FootballInfoApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Controllers
{
     [Authorize]
     [ApiController]
     [Route("api/[controller]")]
     public class CoachController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly ICoachService _coachService;

          public CoachController(IMapper mapper, ICoachService coachService)
          {
               _mapper = mapper;
               _coachService = coachService;
          }

          [HttpGet("/coaches/{id}")]
          [AllowAnonymous]
          public async Task<IActionResult> Get(int id)
          {
               var coach = await _coachService.GetCoachById(id);

               if (coach == null)
                    return NotFound();

               return Ok(coach);

          }
     }
}
