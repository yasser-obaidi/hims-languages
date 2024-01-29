using HimsLanguages.Data.Entities;
using HimsLanguages.Data.Repo;
using HimsLanguages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;
namespace HimsLanguages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : Controller
    {
        
        private readonly ILanguagesService _service;
        //private readonly IMemoryCache _memoryCache;
        //private readonly LanguagesRepo _language;


        public CashController (ILanguagesService service)
        {
            //_memoryCache = memoryCache;
           // _language= language;
            _service= service;  
        }
       

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



            // GET api/<DataController>/5
            [HttpGet("{key}")]
            public IActionResult Get(string key)
            {
                if (string.IsNullOrEmpty(key))
                {
                    return BadRequest();
                }

                var data = _service.Get(key);

                return data == null ? NotFound() : new OkObjectResult(data);
            }

        // POST api/<DataController>
        [HttpPost]
        public IActionResult Post([FromBody] Languages model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            _service.Upsert(model.UniqueSeoCode, model.Name);

            return Ok();
        }

        //// PUT api/<DataController>/5
        //[HttpPut()]
        //public IActionResult Put([FromBody] DataModel model)
        //{
        //    if (model == null)
        //    {
        //        return BadRequest();
        //    }

        //    _dataService.Upsert(model.Key, model.Value, TimeSpan.FromSeconds(20));

        //    return Ok();
        //}

        //// DELETE api/<DataController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(string key)
        //{
        //    if (string.IsNullOrEmpty(key))
        //    {
        //        return BadRequest();
        //    }

        //    _dataService.Delete(key);

        //    return Ok();
        //}
    }
    }

