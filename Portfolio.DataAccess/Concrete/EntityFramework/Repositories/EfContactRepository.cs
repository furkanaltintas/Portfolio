using Microsoft.EntityFrameworkCore;
using Portfolio.Core.DataAccess.Concrete.EntityFramework;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entities.Concrete;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Repositories
{
    internal class EfContactRepository : EfEntityRepositoryBase<Contact>, IContactRepository
    {
        public EfContactRepository(DbContext context) : base(context)
        {
        }
    }
}
