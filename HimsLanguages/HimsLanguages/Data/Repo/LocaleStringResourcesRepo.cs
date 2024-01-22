using HimsLanguages.Data.Entities;
using HimsLanguages.Repo.Commen;
using Microsoft.EntityFrameworkCore;

namespace HimsLanguages.Data.Repo
{
    public class LocaleStringResourcesRepo : Repository<LocaleStringResources>
    {
        public LocaleStringResourcesRepo(Context context) : base(context)
        {

        }
        public async Task<List<LocaleStringResources>> GetAll()
        {
            return await Get().ToListAsync();
        }
        public async Task<LocaleStringResources> GetById(int id)
        {
            var result = await context.LocaleStringResource
                .FirstOrDefaultAsync(e => e.Id == id 
                && e.IsDeleted == false
                );

            if (result != null)
            {
                return await context.LocaleStringResource
                .FirstOrDefaultAsync(e => e.Id == id);

            }
            throw new Exception("id not found");
        }
        public async Task<string> Add(LocaleStringResources input)
        {
            await AddAsync(input);
            await context.SaveChangesAsync();

           return "Added successfully";
        }
       
        public async Task<string> UpdateLocale(LocaleStringResources locale)
        {
            var result = await context.LocaleStringResource
                .FirstOrDefaultAsync(e => e.Id == locale.Id && e.IsDeleted == false);

            if (result != null)
            {
                result.ResourceName = locale.ResourceName;
                result.ResourceValue = locale.ResourceValue;



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
        public async Task<string> DeleteLocale(int id)
        {
            var locale = await context.LocaleStringResource.FindAsync(id);
            if (locale != null)
            {
                if (locale.IsDeleted == true)
                {
                    return "already deleted";
                }
                locale.IsDeleted = true;
                await context.SaveChangesAsync();
                locale.DeletedAt = DateTime.Now;
                return "deleted successfully";
            }
            throw new Exception("not deleted");
        }
    }
    
    }
