using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Portfolio.Core.DataAccess.Concrete.EntityFramework.Extensions
{
    public static class EntityRepositoryExtensions
    {
        public static async Task<IList<TEntity>> GetAllQuery<TEntity>(this IQueryable<TEntity> values, Expression<Func<TEntity, bool>>? expression = null, params Expression<Func<TEntity, object>>[] includeProperties)
            where TEntity : class, IEntity, new()
        {
            var query = values;

            if (expression is not null)
                query = query.Where(expression);

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }

        public static async Task<TEntity?> GetQuery<TEntity>(this IQueryable<TEntity> values, Expression<Func<TEntity, bool>>? expression = null, bool tracking = false, params Expression<Func<TEntity, object>>[] includeProperties)
    where TEntity : class, IEntity, new()
        {
            var query = values;

            if (expression is not null)
                query = query.Where(expression);

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return tracking
                ? await query.AsTracking().SingleOrDefaultAsync()
                : await query.AsNoTracking().SingleOrDefaultAsync();
        }
    }
}