using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.Concrete
{
    public class Resume : BaseEntity<int>, IEntity
    {
        public string Title { get; set; } = null!;
        public string SubTitle { get; set; } = null!;
        public string DateRange { get; set; } = null!;
    }
}