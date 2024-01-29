using HimsLanguages.Data;
using HimsLanguages.Data.Entities;
using HimsLanguages.Data.Repo;
using HimsLanguages.Repo.Commen;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace HimsLanguages.Services
{
    public interface ILanguagesService
    {
        string? Get(string key);

        // insert or update
        void Upsert(string key, string value, ICollection<LocaleStringResources> localeStringResource);

        // insert or update
        void Upsert(string key, string value, TimeSpan expiration);
        void Upsert(string uniqueSeoCode, string name);

        // void Delete(string key);
    }
    public class LanguagesService: ILanguagesService
    {
        private readonly IUnitOfWork unit;
        private readonly LanguagesRepo language;
        private readonly IMemoryCache _memoryCache;

        public LanguagesService(IUnitOfWork unitOfWork, LanguagesRepo _language, IMemoryCache memoryCache)
        { //injection repo in service
            unit = unitOfWork;
            language = _language;
            _memoryCache = memoryCache;
        }
        public string? Get(string key)
        {
            var found = _memoryCache.TryGetValue(key, out var value);
            return found ? value.ToString() : null;
        }

        // insert or update
       
        public void Upsert(string Name, string LanguageCulture)
        {
            try
            {
                var s = _memoryCache.Set(Name, LanguageCulture);
            }
            catch (Exception ex)
            {
                // deal with the exception, or log error
            }
        }

        // insert or update
        public void Upsert(string key, string value, TimeSpan expiration)
        {
            try
            {
                var s = _memoryCache.Set(key, value, expiration);
            }
            catch (Exception ex)
            {
                // deal with the exception, or log error
            }
        }









        public IEnumerable<Languages> GetAllLanguages()
        {
            var languages = language.GetAllLanguages();
            return languages;
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

        public void Upsert(string key, string value, ICollection<LocaleStringResources> localeStringResource)
        {
            throw new NotImplementedException();
        }
    }
}