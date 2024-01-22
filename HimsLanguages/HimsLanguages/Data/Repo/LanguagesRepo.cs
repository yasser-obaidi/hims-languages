using HimsLanguages.Data.Entities;
using HimsLanguages.Repo.Commen;
using Microsoft.EntityFrameworkCore;
using HimsLanguages.Data;
using System.Diagnostics.Metrics;
using MySqlX.XDevAPI.Common;
using HimsLanguages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using HimsLanguages.Data;

namespace HimsLanguages.Data.Repo

{


    public class LanguagesRepo : Repository<Languages>
    {
        public LanguagesRepo(Context context) : base(context)
        {

        }
        public async Task<Languages> Add(Languages input)
        {
            await AddAsync(input);
            await context.SaveChangesAsync();

            return input;
        }
        public async Task<List<Languages>> GetAll()
        {
            return await Get().ToListAsync();
        }
        public async Task<Languages> GetById(int id)

        {
            return await context.Languages
                .FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted== false)  ?? throw new Exception("id not found");

        }



        public async Task<string> UpdateLanguages(Languages languages)
        {
            //var result = await context.Languages
            //    .FirstOrDefaultAsync(e => e.Id == languages.Id);
            var result = await context.Languages
                .FirstOrDefaultAsync(e => e.Id == languages.Id);

            if (result != null)
            {
                result.Name = languages.Name;
                result.LanguageCulture = languages.LanguageCulture;
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {

                    return "updated ";
                }
                else
                {
                    throw new Exception("not updated");

                }
            }

            throw new Exception("id not found");

        }

        public async Task<string> DeleteLanguages(int id)
        {
            var language = await context.Languages.FindAsync(id);
            if (language != null)
            {
                if (language.IsDeleted == true)
                {
                    return "already deleted";
                }

                //context.Countries.Remove(country);
                language.IsDeleted = true;
                await context.SaveChangesAsync();
                language.DeletedAt = DateTime.Now;
                return "deleted successfully";
            }
            throw new Exception("not deleted");
        }
    }
}

      

           
