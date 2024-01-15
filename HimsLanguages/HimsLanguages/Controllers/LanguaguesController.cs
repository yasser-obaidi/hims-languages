using HimsLanguages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HimsLanguages.Data.Entities;
using HimsLanguages.Data.Repo;
using HimsLanguages.Repo.Commen;
using HimsLanguages;
using HimsLanguages.Services;
using HimsLanguages.Data;
using System.Diagnostics.Metrics;


namespace HimsLanguages.Controllers
{
    public class LanguaguesController : Controller
    {
        private readonly LanguagesRepo _Repo;
        private readonly LanguagesService service;

        public LanguaguesController(LanguagesRepo languagesRepo, LanguagesService languagesService)
        {
            service = languagesService;
            _Repo = languagesRepo;


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
        public async Task<IActionResult> Add(Languages input)
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

            //}
            //[HttpPost("Update")]
            //public async Task<IActionResult> UpdateCountry(Languages input)
            //{
            //    try
            //    {
            //        var res = await service.UpdateLanguages(input);

            //        return Ok(res);

            //    }
            //    catch (Exception ex)
            //    {
            //        return BadRequest(ex.Message);
            //    }

            //}
            //[HttpDelete("Delete")]
            //public async Task<IActionResult> Delete(int input)
            //{
            //    try
            //    {
            //        return Ok(await service.DeleteLanguages(input));
            //    }
            //    catch (Exception ex)
            //    {
            //        return BadRequest(ex.Message);
            //    }



            //}
        }
    }
}