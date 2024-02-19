using ECommerce.Application.Interfaces.Repository.Common;
using ECommerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repository.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DbContext context;
        private readonly DbSet<T> dbset;


        public BaseRepository(DbContext context)
        {
            this.context = context;
            dbset = this.context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbset.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetFilterAll(Expression<Func<T, bool>> filter = null)
        {
            return await dbset.Where(filter).ToListAsync();
        }

        public async Task<T> GetByID(Guid id)
        {
            return await dbset.FirstOrDefaultAsync(x => x.ID == id);
        }


        public void AddEntity(T entity)
        {
            dbset.Add(entity);
        }

        public void UpdateEntity(T entity)
        {
            dbset.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void DeleteEntity(T entity, bool isSoftDelete)
        {
            if (isSoftDelete)
            {
                entity.IsActive = false;
                UpdateEntity(entity);
            }
            else
            {
                dbset.Remove(entity);
            }
        }

        public async Task<T> GetFilterByCondition(Expression<Func<T, bool>> filter = null)
        {
            return await dbset.FirstOrDefaultAsync(filter);
        }
    }
}
