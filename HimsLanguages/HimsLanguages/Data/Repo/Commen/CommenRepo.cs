
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using HimsLanguages.Data;
using HimsLanguages.Data.Entities.Commen;
using HimsLanguages.Data.Entities;


namespace HimsLanguages.Repo.Commen
{
    public class Repository<TEntity> where TEntity : BaseEntity
    {
        public Context context;
        private DbSet<TEntity> dbSet;

        protected Repository(Context context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        /// <summary>
        /// this function shuode replace dpset.Where() for every entity
        /// </summary>
        /// <param name="filter">landa expiration</param>
        /// <param name="includeProperties">string spirited by , of the entity want to included</param>
        /// <returns></returns>
        protected virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }


            return query;

        }

        protected virtual async Task<TEntity> GetByIDAsync(object id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity?.DeletedAt == null)
                return null;
            return entity;
        }

        protected virtual async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        protected virtual async Task Delete(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            Delete(entityToDelete);
        }

        protected virtual void Delete(TEntity entityToDelete)
        {
            dbSet.Remove(entityToDelete);
        }




        //public virtual void UpdateAsync(TEntity entityToUpdate)
        //{
        //    dbSet.Attach(entityToUpdate);
        //    context.Entry(entityToUpdate).State = EntityState.Modified;
        //}
    }
}


