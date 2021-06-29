using AutoMapper;
using FootballInfoApp.API.Dtos.Standings;
using FootballInfoApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
     [Authorize]
     public class StandingsController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly IStandingsService _standingService;

          public StandingsController(IMapper mapper, IStandingsService standingService)
          {
               _mapper = mapper;
               _standingService = standingService;
          }

          [HttpGet("/standing")]
          [AllowAnonymous]
          public async Task<List<StandingDto>> Get()
          {
               var standing = await _standingService.Get();

               var standingDto = _mapper.Map<List<StandingDto>>(standing);

               return standingDto;
          }

          [HttpGet("/standing/{teamId}")]
          [AllowAnonymous]
          public async Task<StandingDto> Get(int teamId)
          {
               var standing = await _standingService.GetTeam(teamId);

               var standingDto = _mapper.Map<StandingDto>(standing);

               return standingDto;
          }

     }
}
