using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.Concrete
{
    public class About : BaseEntity<int>, IEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}