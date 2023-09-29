using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities.Concrete;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Configurations;

public class AboutConfiguration : IEntityTypeConfiguration<About>
{
    public void Configure(EntityTypeBuilder<About> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();

        builder.Property(a => a.Title).HasMaxLength(250);
        builder.Property(a => a.Title).IsRequired();

        builder.Property(a => a.Description).HasMaxLength(500);
        builder.Property(a => a.Description).IsRequired();

        builder.Property(a => a.CreatedDate).IsRequired();
        builder.Property(a => a.IsActive).IsRequired();
        builder.Property(a => a.IsDeleted).IsRequired();

        builder.ToTable("Abouts");

        builder.HasData(new About
        {
            Id = 1,
            Title = "Ben Kimim ?",
            Description = "Ben Furkan Altıntaş. Düzce Üniversitesi Mezunuyum.",
            CreatedDate = DateTime.Now,
            IsActive = true,
            IsDeleted = false
        });
    }
}