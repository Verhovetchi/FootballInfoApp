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
     public class StadiumController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly IStadiumService _stadiumService;

          public StadiumController(IMapper mapper, IStadiumService stadiumService)
          {
               _mapper = mapper;
               _stadiumService = stadiumService;
          }

          [HttpGet("/stadium")]
          public async Task<IActionResult> Get(int id)
          {
               var stadium = await _stadiumService.GetStadiumByTeamId(id);

               return Ok(stadium);
          }
     }
}
