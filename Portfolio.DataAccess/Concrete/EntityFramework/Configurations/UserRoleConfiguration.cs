using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("UserRoles");


            builder.HasData(
                new IdentityUserRole<string>()
                {
                    UserId = "A041999F-3286-4278-A81A-9006BBB92478",
                    RoleId = "701231D6-8EAE-4E98-A56D-65A8FDE7C0E6"
                });
        }
    }
}
