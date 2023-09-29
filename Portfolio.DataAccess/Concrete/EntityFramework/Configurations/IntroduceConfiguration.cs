using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities.Concrete;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Configurations;

public class IntroduceConfiguration : IEntityTypeConfiguration<Introduce>
{
    public void Configure(EntityTypeBuilder<Introduce> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();

        builder.Property(i => i.Title).IsRequired();
        builder.Property(i => i.Title).HasMaxLength(100);

        builder.Property(i => i.Description).IsRequired();
        builder.Property(i => i.Description).HasMaxLength(250);

        builder.Property(i => i.ExperienceContent).IsRequired();
        builder.Property(i => i.ExperienceContent).HasMaxLength(50);

        builder.Property(i => i.ProjectContent).IsRequired();
        builder.Property(i => i.ProjectContent).HasMaxLength(50);

        builder.Property(i => i.CreatedDate).IsRequired();
        builder.Property(i => i.IsActive).IsRequired();
        builder.Property(i => i.IsDeleted).IsRequired();

        builder.ToTable("Introduces");

        builder.HasData(new Introduce
        {
            Id = 1,
            Title = "Merhaba ben Furkan",
            Description = "And I'm sick of waiting patiently for someone that won't even arrive",
            ExperienceContent = "Yazılım Tecrübesi",
            ExperiencePeriod = 0,
            ProjectContent = "Toplam Proje Sayısı (GitHub)",
            ProjectCount = 0,
            CreatedDate = DateTime.Now,
            IsActive = true,
            IsDeleted = false
        });
    }
}
