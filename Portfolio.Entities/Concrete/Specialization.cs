using Portfolio.Core.Entities.Abstract;
using Portfolio.Core.Entities.Concrete;

namespace Portfolio.Entities.Concrete;

public class Specialization : BaseEntity<int>, IEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? TotalProject { get; set; }
    public string? IconName { get; set; }
}