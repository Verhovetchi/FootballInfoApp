using FootballInfoApp.API.Services.Interfaces;
using FootballInfoApp.Domain;
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
     public class NewController : ControllerBase
     {
          private readonly INewService _newService;

          public NewController(INewService newService)
          {
               _newService = newService;
          }

          [HttpGet("/news/{pageId}")]
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

          [HttpGet("/new/{newId}")]
          public async Task<IActionResult> GetNewById(int newId)
          {
               return Ok(await _newService.GetNewById(newId));
          }
     }
}