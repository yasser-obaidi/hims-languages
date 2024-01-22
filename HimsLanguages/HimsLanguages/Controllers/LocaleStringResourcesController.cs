using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HimsLanguages.Data.Entities;
using HimsLanguages.Data.Repo;
using HimsLanguages.Data.Repo;
using HimsLanguages.Services;
using HimsLanguages.Data;
using System.Diagnostics.Metrics;

namespace HimsLanguages.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocaleStringResourcesController : Controller
    {
        
        
            private readonly LocaleStringResourcesRepo _Repo;
            private readonly LocaleStringResourcesService service;

            public LocaleStringResourcesController(LocaleStringResourcesRepo localeRepo, LocaleStringResourcesService localeService)
            {
                _Repo = localeRepo;
                service = localeService;


            }
            [HttpGet("GetAll")]
            public async Task<IActionResult> GetAsync()
            {
                return Ok(await service.GetAll());
            }

            [HttpGet("GetById")]
            public async Task<IActionResult> GetById(int id)
            {
                try
                {
                    return Ok(await service.GetById(id));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            [HttpPost("Add")]
            public async Task<IActionResult> Add(LocaleStringResources input)
            {
                try
                {
                    var res = await service.Add(input);

                    return Ok(res);



                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateCountry(LocaleStringResources input)
        {
            try
            {
                var res = await service.UpdateLocale(input);

                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //[HttpDelete("Delete")]
        //public async Task<IActionResult> Delete(int input)
        //{
        //    try
        //    {
        //        return Ok(await service.DeleteLocale(input));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }



        //}
    }
    }
