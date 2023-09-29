using Microsoft.EntityFrameworkCore;
using Portfolio.Core.DataAccess.Concrete.EntityFramework;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entities.Concrete;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfAboutRepository : EfEntityRepositoryBase<About>, IAboutRepository
    {
        public EfAboutRepository(DbContext context) : base(context)
        {
        }
    }
}