using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities.Concrete;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Property(c => c.FullName).IsRequired();
        builder.Property(c => c.FullName).HasMaxLength(100);

        builder.Property(c => c.Email).IsRequired();
        builder.Property(c => c.Email).HasMaxLength(75);

        builder.Property(c => c.Phone).IsRequired();
        builder.Property(c => c.Phone).HasMaxLength(25);

        builder.Property(c => c.Subject).IsRequired();
        builder.Property(c => c.Subject).HasMaxLength(100);

        builder.Property(c => c.Message).IsRequired();
        builder.Property(c => c.Message).HasMaxLength(1000);

        builder.Property(c => c.CreatedDate).IsRequired();
        builder.Property(c => c.IsActive).IsRequired();
        builder.Property(c => c.IsDeleted).IsRequired();

        builder.ToTable("Contacts");

        builder.HasData(new Contact
        {
            Id = 1,
            FullName = "Berke Altıntaş",
            Email = "berketest@gmail.com",
            Phone = "+90 555 555 55 55",
            Subject = "Deneme",
            Message = "Bu bir deneme mesajıdır",
            CreatedDate = DateTime.Now,
            IsActive = true,
            IsDeleted = false
        });
    }
}
