using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.Concrete;

public class Skill : BaseEntity<int>, IEntity
{
    public string Name { get; set; } = null!;
    public string IconName { get; set; } = null!;
    public short Point { get; set; } = 0;
}