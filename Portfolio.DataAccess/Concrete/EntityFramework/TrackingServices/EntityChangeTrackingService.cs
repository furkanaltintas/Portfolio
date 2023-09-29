using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities.Abstract;

namespace Portfolio.DataAccess.Concrete.EntityFramework.TrackingServices
{
    public class EntityChangeTrackingService
    {
        private readonly DbContext _dbContext;

        public EntityChangeTrackingService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void TrackEntityChanges<TEntity>(TEntity entity) where TEntity : BaseEntity<int>
        {
            var entry = _dbContext.Entry(entity);

            switch (entry.State)
            {
                case EntityState.Added:
                    {
                        entity.CreatedDate = DateTime.Now;
                        entity.IsActive = true;
                        break;
                    }
                case EntityState.Modified:
                    {
                        entry.Property(p => p.CreatedDate).IsModified = false; // Bu alan hakkında bir güncelleme olmayacağını belirttik
                        entity.UpdatedDate = DateTime.Now;
                        break;
                    }
                case EntityState.Deleted:
                    {
                        entity.DeletedDate = DateTime.Now;
                        entity.IsDeleted = true;
                        break;
                    }
            }


        }
    }
}