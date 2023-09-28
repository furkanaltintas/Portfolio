using Portfolio.Core.Entities.Abstract;
using Portfolio.Core.Entities.Concrete;

namespace Portfolio.Entities.Concrete
{
    public class About : BaseEntity<int>, IEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}