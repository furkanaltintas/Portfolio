using Portfolio.Core.DataAccess.Abstract;
using Portfolio.Core.DataAccess.Concrete.EntityFramework;
using Portfolio.DataAccess.Abstract;
using Portfolio.DataAccess.Concrete.EntityFramework.Contexts;

namespace Portfolio.DataAccess.Concrete
{
    public class Repository : IRepository
    {
        private readonly PortfolioContext _context;

        public Repository(PortfolioContext context) =>
            _context = context;

        IEntityRepository<TEntity> IRepository.GetRepository<TEntity>() =>
            new EfEntityRepositoryBase<TEntity>(_context)!;


        TRepository IRepository.GetRepository<TEntity, TRepository>() =>
            (TRepository)Activator.CreateInstance(typeof(TRepository), _context)!;


        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();

        public void Save() =>
            _context.SaveChanges();
    }
}