using AutoMapper;
using FootballInfoApp.API.Dtos.Stadiums;
using FootballInfoApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     [Authorize]
     public class StadiumsController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly IStadiumsService _stadiumService;

          public StadiumsController(IMapper mapper, IStadiumsService stadiumService)
          {
               _mapper = mapper;
               _stadiumService = stadiumService;
          }

          [HttpGet("{id}")]
          [AllowAnonymous]
          public async Task<StadiumDto> Get(int id)
          {
               var stadium = await _stadiumService.GetStadiumByTeamId(id);

               var stadiumDto = _mapper.Map<StadiumDto>(stadium);

               return stadiumDto;
          }

          [HttpGet]
          [AllowAnonymous]
          public async Task<IEnumerable<StadiumDto>> Get()
          {
               var stadium = await _stadiumService.GetAllStadiums();

               var stadiumDto = _mapper.Map<List<StadiumDto>>(stadium);

               return stadiumDto;
          }
     }
}
