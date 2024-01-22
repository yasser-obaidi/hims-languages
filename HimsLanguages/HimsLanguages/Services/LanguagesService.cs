using HimsLanguages.Data;
using HimsLanguages.Data.Entities;
using System.Diagnostics.Metrics;

namespace HimsLanguages.Services
{
    public class LanguagesService
    {
        private readonly IUnitOfWork unit;
        public LanguagesService(IUnitOfWork unitOfWork)
        { //injection repo in service
            unit = unitOfWork;
        }
        public async Task<List<Languages>> GetAll()
        {
            return await unit.languagesRepo.GetAll();
        }
        public async Task<Languages> GetById(int id)
        {
            var res = await unit.languagesRepo.GetById(id);
            return res;
        }
        public async Task<Languages> Add(Languages input)
        {
            var existingName = unit.languagesRepo.context
                .Languages.FirstOrDefault(i => i.Name == input.Name);
            var existingLanguageCulture = unit.languagesRepo.context
                .Languages.FirstOrDefault(i => i.LanguageCulture == input.LanguageCulture);


            if (existingName != null)
            {
                throw new Exception("Name  already exist");
            }
            if (existingLanguageCulture != null)
            {
                throw new Exception("LanguageCulture  already exist");
            }
            var res = await unit.languagesRepo.Add(input);
            return res;






        }
       
        
    

    public async Task<string> UpdateLanguages(Languages languages)
        {
            var existingName = unit.languagesRepo.context
                .Languages.FirstOrDefault(i => i.Name == languages.Name);
            var existingLanguageCulture = unit.languagesRepo.context
                .Languages.FirstOrDefault(i => i.LanguageCulture == languages.LanguageCulture);




            if (existingName != null)
            {
                throw new Exception("Name  already exist");
            }
            if (existingLanguageCulture != null)
            {
                throw new Exception("LanguageCulture  already exist");
            }

            var res = await unit.languagesRepo.UpdateLanguages(languages);
            return res;

        }
        public async Task<string> DeleteLanguages(int id)
        {
            var country = await unit.languagesRepo.DeleteLanguages(id);
            return country;
        }

    }
}