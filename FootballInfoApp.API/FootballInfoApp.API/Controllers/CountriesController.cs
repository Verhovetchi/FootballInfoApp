using AutoMapper;
using FootballInfoApp.API.Dtos.Countries;
using FootballInfoApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class CountriesController : ControllerBase
     {
          private readonly ICountriesService _countryService;
          private readonly IMapper _mapper;

          public CountriesController(ICountriesService countryService, IMapper mapper)
          {
               _countryService = countryService;
               _mapper = mapper;
          }

          [HttpGet]
          [AllowAnonymous]
          public async Task<IActionResult> Get()
          {
               var countries = await _countryService.GetAll();

               //var countryDto = _mapper.Map<List<CountryDto>>(countries);
               
               return Ok(countries);
          }
     }
}
