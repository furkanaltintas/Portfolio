using Portfolio.Core.Entities.Abstract;
using Portfolio.Core.Entities.Concrete;

namespace Portfolio.Entities.Concrete;

public class Introduce : BaseEntity<int>, IEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public short ExperiencePeriod { get; set; }
    public string ExperienceContent { get; set; } = null!;

    public short ProjectCount { get; set; }
    public string ProjectContent { get; set; } = null!;
}