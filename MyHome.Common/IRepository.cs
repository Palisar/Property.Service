using System.Linq.Expressions;

namespace MyHome.Common
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateAsync(T entity);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task RemoveAsync(int id);
        Task UpdateAsync(T entity);

    }
}