﻿using AutoMapper;
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
     public class StandingController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly IStandingService _standingService;

          public StandingController(IMapper mapper, IStandingService standingService)
          {
               _mapper = mapper;
               _standingService = standingService;
          }

          [HttpGet("/standing")]
          [AllowAnonymous]
          public async Task<IActionResult> Get()
          {
               var standing = await _standingService.Get();

               return Ok(standing);
          }

          [HttpGet("/standing/{teamId}")]
          [AllowAnonymous]
          public async Task<IActionResult> Get(int teamId)
          {
               var res = await _standingService.GetTeam(teamId);

               return Ok(res);
          }

     }
}
