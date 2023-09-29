using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities.Concrete;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Configurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();

        builder.Property(s => s.Name).IsRequired();
        builder.Property(s => s.Name).HasMaxLength(50);

        builder.Property(s => s.IconName).IsRequired();
        builder.Property(s => s.IconName).HasMaxLength(100);

        builder.Property(s => s.Point).IsRequired();

        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.IsActive).IsRequired();
        builder.Property(s => s.IsDeleted).IsRequired();

        builder.ToTable("Skills");

        builder.HasData(
            new Skill
            {
                Id = 1,
                Name = "Net Core",
                IconName = "...",
                Point = 60,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Skill
            {
                Id = 2,
                Name = "Wordpress",
                IconName = "...",
                Point = 45,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Skill
            {
                Id = 3,
                Name = "Angular",
                IconName = "...",
                Point = 35,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            });
    }
}