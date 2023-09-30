using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities.Concrete;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(a => a.Id);

        // Indexes for "normalized" username and email, to allow efficient lookups
        builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
        builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

        // A concurrency token for use with the optimistic concurrency checking
        builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

        // Limit the size of columns to use efficient database types
        builder.Property(u => u.UserName).HasMaxLength(50);
        builder.Property(u => u.NormalizedUserName).HasMaxLength(50);
        builder.Property(u => u.Email).HasMaxLength(100);
        builder.Property(u => u.NormalizedEmail).HasMaxLength(100);


        // Picture
        builder.Property(a => a.Picture).IsRequired();
        builder.Property(a => a.Picture).HasMaxLength(250);

        // About
        builder.Property(a => a.FirstName).HasMaxLength(30);
        builder.Property(a => a.LastName).HasMaxLength(30);
        builder.Property(a => a.Degree).HasMaxLength(50);

        // Maps to the AspNetUsers table
        builder.ToTable("Users");

        var adminUser = new User
        {
            Id = "A041999F-3286-4278-A81A-9006BBB92478",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            PhoneNumber = "+905555555555",
            Picture = "",
            FirstName = "Admin",
            LastName = "User",
            Degree = "Backend Developer",
            Address = "İstanbul, Türkiye",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        };
        adminUser.PasswordHash = CreatePasswordHash(adminUser, "adminuser");


        builder.HasData(adminUser);

    }

    private string CreatePasswordHash(User user, string password)
    {
        var passwordHasher = new PasswordHasher<User>();
        return passwordHasher.HashPassword(user, password);
    }
}