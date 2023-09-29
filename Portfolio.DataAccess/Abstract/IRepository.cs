using Portfolio.Core.DataAccess.Abstract;
using Portfolio.Core.Entities.Abstract;

namespace Portfolio.DataAccess.Abstract
{
    public interface IRepository
    {
        IEntityRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity, new();

        TRepository GetRepository<TEntity, TRepository>()
            where TEntity : class, IEntity, new()
            where TRepository : IEntityRepository<TEntity>;

        Task SaveAsync();
        void Save();
    }
}