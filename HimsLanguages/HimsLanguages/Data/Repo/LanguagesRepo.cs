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
                .FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception("id not found");

        }
        
        //public async Task<List<ActivityLog>> GetActivityLogByActivityLogTypeName(ActivityLogModel activityLog)
        //{
        //    var activityLogId = context.ActivityLogs
        //       .Where(log => log.ActivityLogTypes. == activityLog)
        //       .Select(log => log.LogId)
        //       .FirstOrDefault();
        //    return activityLogId;

            //var result = new List<ActivityLog>();

            //result = await context.ActivityLogs
            //    .Where(x =>
            //        (x. == activityLog.Id))
            //    .ToListAsync();

            //return result;
        }

    }


            //ActivityLog activityLog = context.ActivityLogs
            //    .Where(al => al.ActivityLogType.Name == Name)
            //    .FirstOrDefault();

            //if (activityLog != null)
            //{
            //    return activityLog;
            //}
            //else
            //{
            //    // Handle the case where no log is found for the given type
            //    throw new Exception("id not found");
           
