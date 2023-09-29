using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities.Concrete;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Configurations;

public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
{
    public void Configure(EntityTypeBuilder<SocialMedia> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();

        builder.Property(s => s.Name).IsRequired();
        builder.Property(s => s.Name).HasMaxLength(50);

        builder.Property(s => s.IconName).IsRequired();
        builder.Property(s => s.IconName).HasMaxLength(30);

        builder.Property(s => s.Link).IsRequired();
        builder.Property(s => s.Link).HasMaxLength(100);

        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.IsActive).IsRequired();
        builder.Property(s => s.IsDeleted).IsRequired();

        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.IsActive).IsRequired();
        builder.Property(s => s.IsDeleted).IsRequired();

        builder.ToTable("SocialMedias");

        builder.HasData(
            new SocialMedia
            {
                Id = 1,
                Name = "GitHub",
                IconName = "lab la-github",
                Link = "https://github.com/FurkanAltintas",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new SocialMedia
            {
                Id = 2,
                Name = "Linkedin",
                IconName = "lab la-linkedin",
                Link = "https://www.linkedin.com/in/furkanaltintas/"
            });
    }
}