using Portfolio.Core.Entities.Abstract;
using Portfolio.Core.Entities.Concrete;

namespace Portfolio.Entities.Concrete
{
    public class SocialMedia : BaseEntity<int>, IEntity
    {
        public string Name { get; set; } = null!;
        public string IconName { get; set; } = null!;
        public string Link { get; set; } = null!;
    }
}