using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities.Concrete;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Configurations;

public class MenuHeaderConfiguration : IEntityTypeConfiguration<MenuHeader>
{
    public void Configure(EntityTypeBuilder<MenuHeader> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();

        builder.Property(m => m.Header).IsRequired();
        builder.Property(m => m.Header).HasMaxLength(75);

        builder.Property(a => a.CreatedDate).IsRequired();
        builder.Property(a => a.IsActive).IsRequired();
        builder.Property(a => a.IsDeleted).IsRequired();

        builder.HasOne<Menu>(mh => mh.Menu)
            .WithMany(m => m.MenuHeaders)
            .HasForeignKey(mh => mh.MenuId);

        builder.ToTable("MenuHeaders");

        //builder.HasData(
        //    new MenuHeader
        //    {
        //        Id = 1,
        //        MenuId = 3,
        //        Header = "Education & Experience",
        //        CreatedDate = DateTime.Now,
        //        IsActive = true,
        //        IsDeleted = false
        //    },
        //    new MenuHeader
        //    {
        //        Id = 2,
        //        MenuId = 4,
        //        Header = "My Specializations",
        //        CreatedDate = DateTime.Now,
        //        IsActive = true,
        //        IsDeleted = false
        //    },
        //    new MenuHeader
        //    {
        //        Id = 3,
        //        MenuId = 5,
        //        Header = "My Advantages",
        //        CreatedDate = DateTime.Now,
        //        IsActive = true,
        //        IsDeleted = false
        //    },
        //    new MenuHeader
        //    {
        //        Id = 4,
        //        MenuId = 7,
        //        Header = "Trusted by Hundered Clients",
        //        CreatedDate = DateTime.Now,
        //        IsActive = true,
        //        IsDeleted = false
        //    },
        //    new MenuHeader
        //    {
        //        Id = 5,
        //        MenuId = 8,
        //        Header = "Let's Work Together!",
        //        CreatedDate = DateTime.Now,
        //        IsActive = true,
        //        IsDeleted = false
        //    });
    }
}