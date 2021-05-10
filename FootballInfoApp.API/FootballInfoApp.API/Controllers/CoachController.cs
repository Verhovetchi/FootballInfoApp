using AutoMapper;
using FootballInfoApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
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
          public async Task<IActionResult> Get(int id)
          {
               var coach = await _coachService.GetCoachById(id);

               if (coach == null)
                    return NotFound();

               return Ok(coach);

          }
     }
}
