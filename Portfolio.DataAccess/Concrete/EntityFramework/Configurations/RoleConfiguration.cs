using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities.Concrete;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        // Primary key
        builder.HasKey(r => r.Id);

        // Index for "normalized" role name to allow efficient lookups
        builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

        // Maps to the AspNetRoles table
        builder.ToTable("Roles");

        // A concurrency token for use with the optimistic concurrency checking
        builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

        // Limit the size of columns to use efficient database types
        builder.Property(u => u.Name).HasMaxLength(256);
        builder.Property(u => u.NormalizedName).HasMaxLength(256);


        builder.HasData(
            new Role
            {
                Id = "701231D6-8EAE-4E98-A56D-65A8FDE7C0E6",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
    }
}