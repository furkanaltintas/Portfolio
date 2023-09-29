namespace Portfolio.Core.Entities.Abstract;

public abstract class BaseEntity<TId>
{
    public BaseEntity(TId id)
    {
        Id = id;
    }

    public BaseEntity()
    {
        Id = default!;
    }

    public virtual TId Id { get; set; }

    public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
    public virtual DateTime? UpdatedDate { get; set; }
    public virtual DateTime? DeletedDate { get; set; }

    public virtual bool IsActive { get; set; } = false;

    public virtual bool IsDeleted { get; set; } = false;
}