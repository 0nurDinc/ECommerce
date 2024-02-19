using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Repository.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetFilterAll(Expression<Func<T, bool>> filter = null);
        Task<T> GetFilterByCondition(Expression<Func<T, bool>> filter = null);
        Task<T> GetByID(Guid id);
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity, bool isSoftDelete);
    }
}
