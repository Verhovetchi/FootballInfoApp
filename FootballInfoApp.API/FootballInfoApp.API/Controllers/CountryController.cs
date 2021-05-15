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
     public class CountryController : ControllerBase
     {
          private readonly ICountryService _countryService;

          public CountryController(ICountryService countryService)
          {
               _countryService = countryService;
          }

          [HttpGet("/countries")]
          public async Task<IActionResult> Get()
          {
               var countries = await _countryService.GetAll();
               return Ok(countries);
          }
     }
}
