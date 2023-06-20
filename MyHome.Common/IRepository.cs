
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyHome.Common;

namespace MyHome.Common
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateAsync(T entity);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task RemoveAsync(int id);
        Task UpdateAsync(T entity);

    }
}