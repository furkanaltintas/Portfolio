using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities.Concrete;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Configurations;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();

        builder.Property(m => m.ComponentName).IsRequired();
        builder.Property(m => m.ComponentName).HasMaxLength(50);

        builder.Property(m => m.IconName).IsRequired();
        builder.Property(m => m.IconName).HasMaxLength(30);

        builder.Property(m => m.Header).IsRequired();
        builder.Property(m => m.Header).HasMaxLength(50);

        builder.Property(m => m.Slug).IsRequired();
        builder.Property(m => m.Slug).HasMaxLength(30);

        builder.Property(m => m.Queue).IsRequired();

        builder.Property(m => m.CreatedDate).IsRequired();
        builder.Property(m => m.IsActive).IsRequired();
        builder.Property(m => m.IsDeleted).IsRequired();

        builder.ToTable("Menus");

        builder.HasData(
            new Menu
            {
                Id = 1,
                ComponentName = "Introduce",
                Header = "Introduce",
                Slug = "home",
                IconName = "las la-home",
                Queue = 1,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Menu
            {
                Id = 2,
                ComponentName = "About",
                Header = "About",
                Slug = "about",
                IconName = "lar la-user",
                Queue = 2,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Menu
            {
                Id = 3,
                ComponentName = "Resume",
                Header = "Resume",
                Slug = "resume",
                IconName = "las la-briefcase",
                Queue = 3,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Menu
            {
                Id = 4,
                ComponentName = "Specialization",
                Header = "Services",
                Slug = "services",
                IconName = "las la-stream",
                Queue = 4,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Menu
            {
                Id = 5,
                ComponentName = "Skill",
                Header = "My Skills",
                Slug = "skills",
                IconName = "las la-shapes",
                Queue = 5,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Menu
            {
                Id = 6,
                ComponentName = "Portfolio",
                Header = "Portfolio",
                Slug = "portfolio",
                IconName = "las la-grip-vertical",
                Queue = 6,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Menu
            {
                Id = 7,
                ComponentName = "Testimonial",
                Header = "Testimonial",
                Slug = "testimonial",
                IconName = "lar la-comment",
                Queue = 7,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Menu
            {
                Id = 8,
                ComponentName = "Contact",
                Header = "Contact",
                Slug = "contact",
                IconName = "las la-envelope",
                Queue = 8,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            });
    }
}