using Portfolio.Core.Entities.Abstract;

namespace Portfolio.Entities.Concrete
{
    public class Contact : BaseEntity<int>, IEntity
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}