using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.Concrete;

public class WebSiteDesign : BaseEntity<int>, IEntity
{
    public int MyProperty { get; set; }
}