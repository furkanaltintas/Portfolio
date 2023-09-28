using Portfolio.Core.Entities.Abstract;
using Portfolio.Core.Entities.Concrete;

namespace Portfolio.Entities.Concrete;

public class MenuHeader : BaseEntity<int>, IEntity
{
    public int MenuId { get; set; }
    public string Header { get; set; } = null!;

    public virtual Menu Menu { get; set; } = new();
}