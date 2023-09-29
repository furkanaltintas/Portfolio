using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities.Concrete;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Configurations;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();

        builder.Property(s => s.Title).IsRequired();
        builder.Property(s => s.Title).HasMaxLength(75);

        builder.Property(s => s.Description).IsRequired();
        builder.Property(s => s.Description).HasMaxLength(100);

        builder.Property(s => s.TotalProject).HasMaxLength(25);

        builder.Property(s => s.IconName).HasMaxLength(30);

        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.IsActive).IsRequired();
        builder.Property(s => s.IsDeleted).IsRequired();

        builder.ToTable("Specializations");

        builder.HasData(new Specialization
        {
            Id = 1,
            Title = "Development",
            Description = "I build website go live with Framer, Webflow or WordPress",
            TotalProject = "4 Projects",
            IconName = "las la-code",
            CreatedDate = DateTime.Now,
            IsActive = true,
            IsDeleted = false
        });
    }
}