using Microsoft.EntityFrameworkCore;
using Portfolio.Core.DataAccess.Abstract;
using Portfolio.Core.DataAccess.Concrete.EntityFramework.Extensions;
using Portfolio.Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Portfolio.Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        protected readonly DbContext _context;

        public EfEntityRepositoryBase(DbContext context)
            => _context = context;


        public async Task AddAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                await this.AddAsync(entity);
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
            => await _context.Set<T>().AnyAsync(expression);


        public async Task<int> CountAsync(Expression<Func<T, bool>>? expression = null)
            => expression == null
            ? await _context.Set<T>().CountAsync()
            : await _context.Set<T>().CountAsync(expression);


        public async void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await Task.Run(() => { _context.Set<T>().Remove(entity); });
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params Expression<Func<T, object>>[] includeProperties) =>
            await _context.Set<T>().GetAllQuery(expression, includeProperties);




        public async Task<T?> GetAsync(Expression<Func<T, bool>>? expression = null, bool tracking = false, params Expression<Func<T, object>>[] includeProperties) =>
            await _context.Set<T>().GetQuery(expression, tracking, includeProperties);

        public IQueryable<T> Query() =>
            _context.Set<T>().AsQueryable();

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.UpdateAsync(entity);
            }
        }
    }
}