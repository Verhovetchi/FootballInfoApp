using FootballInfoApp.API.Dtos.News;
using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     [Authorize]
     public class NewsController : ControllerBase
     {
          private readonly INewsService _newService;

          public NewsController(INewsService newService)
          {
               _newService = newService;
          }

          [HttpGet("/news/{pageId}")]
          [AllowAnonymous]
          public async Task<IActionResult> GetPageById(int pageId = 1)
          {
               int pageSize = 5;
               var newsPerPages = await _newService.GetAll();

               var res = newsPerPages.OrderByDescending(x => x.Id).
                    Skip((pageId - 1) * pageSize).
                    Take(pageSize).ToList();

               PageInfo pageInfo = new PageInfo { PageNumber = pageId, PageSize = pageSize, TotalItems = res.Count };
               IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, News = res, TotalNumbersOfItems = newsPerPages.Count };

               return Ok(ivm);
          }

          [HttpGet("/news")]
          [Authorize(Roles = "Admin")]
          public async Task<IActionResult> GetAll()
          {
               var result = await _newService.GetAll();

               return Ok(result.ToList());
          }


          [HttpGet("/new/{newId}")]
          [AllowAnonymous]
          public async Task<IActionResult> GetNewById(int newId)
          {
               return Ok(await _newService.GetNewById(newId));
          }

          [HttpPost("/news")]
          [Authorize(Roles = "Admin")]
          public async Task<IActionResult> Add([FromBody] CreateNewDto dto)
          {
               var _new = await _newService.CreateNew(dto);

               return Ok(_new);
          }

          [HttpPatch("/news/{id}")]
          [Authorize(Roles = "Admin")]
          public async Task<IActionResult> Patch(int id, [FromBody] UpdateNewDto updatedNew)
          {
               var _new = await _newService.UpdateNewById(id, updatedNew);

               return Ok(_new);
          }

          [HttpDelete("/news/{id}")]
          [Authorize(Roles = "Admin")]
          public async Task<IActionResult> Delete(int id)
          {
               await _newService.DeleteNewById(id);
               return NoContent();
          }


     }
}