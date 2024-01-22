using HimsLanguages.Data;
using HimsLanguages.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HimsLanguages.Data.Repo;
using HimsLanguages.Repo.Commen;
using System.Diagnostics.Metrics;
namespace HimsLanguages.Services
{
    public class LocaleStringResourcesService
    {
        private readonly IUnitOfWork unit;
        public LocaleStringResourcesService(IUnitOfWork unitOfWork)
        { //injection repo in service
            unit = unitOfWork;
        }
        public async Task<List<LocaleStringResources>> GetAll()
        {
            return await unit.localeRepo.GetAll();
        }
        public async Task<LocaleStringResources> GetById(int id)
        {
            var res = await unit.localeRepo.GetById(id);
            return res;
        }
        public async Task<string> Add(LocaleStringResources input)
        {
            var existingResourceName = unit.localeRepo.context.LocaleStringResource
                .FirstOrDefault(i => i.ResourceName == input.ResourceName);
           



            if (existingResourceName != null)
            {
                throw new Exception("ResourceName  already exist");
            }
          
            var res = await unit.localeRepo.Add(input);
            return "Added successfully";






        }
        public async Task<string> UpdateLocale(LocaleStringResources locale)
        {
            var existingName = unit.localeRepo.context
           .LocaleStringResource.FirstOrDefault(i => i.ResourceName == locale.ResourceName);
           



            if (existingName != null)
            {
                throw new Exception("Name  already exist");
            }
           
            var res = await unit.localeRepo.UpdateLocale(locale);
            return res;

        }
        //public async Task<string> DeleteLocale(int id)
        //{
        //    var res = await unit.localeRepo.DeleteLocale(id);
        //    return res;
      //  }
    }
}
