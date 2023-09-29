using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.Concrete;

public class MenuHeader : BaseEntity<int>, IEntity
{
    public int MenuId { get; set; }
    public string Header { get; set; } = null!;

    public virtual Menu Menu { get; set; } = new();
}