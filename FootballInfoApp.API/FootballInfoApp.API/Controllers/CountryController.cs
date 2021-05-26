using FootballInfoApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Controllers
{
     [Authorize]
     [ApiController]
     [Route("api/[controller]")]
     public class CountryController : ControllerBase
     {
          private readonly ICountryService _countryService;

          public CountryController(ICountryService countryService)
          {
               _countryService = countryService;
          }

          [HttpGet("/countries")]
          [AllowAnonymous]
          public async Task<IActionResult> Get()
          {
               var countries = await _countryService.GetAll();
               return Ok(countries);
          }
     }
}
