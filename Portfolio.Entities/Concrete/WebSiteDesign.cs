using Portfolio.Core.Entities.Abstract;
using Portfolio.Core.Entities.Concrete;

namespace Portfolio.Entities.Concrete;

public class WebSiteDesign : BaseEntity<int>, IEntity
{
    public int MyProperty { get; set; }
}