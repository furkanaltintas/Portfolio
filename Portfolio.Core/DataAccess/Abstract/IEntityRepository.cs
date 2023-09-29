using Portfolio.Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Portfolio.Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // Read
        Task<T?> GetAsync(Expression<Func<T, bool>>? expression = null, bool tracking = false, params Expression<Func<T, object>>[] includeProperties);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> Query();

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<int> CountAsync(Expression<Func<T, bool>>? expression = null);


        // Write
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);


        Task AddRange(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);
    }
}