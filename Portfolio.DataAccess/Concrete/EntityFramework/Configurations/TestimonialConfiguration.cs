using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities.Concrete;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Configurations;

public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
{
    public void Configure(EntityTypeBuilder<Testimonial> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();


        builder.Property(t => t.FullName).IsRequired();
        builder.Property(t => t.FullName).HasMaxLength(100);


        builder.Property(t => t.Degree).IsRequired();
        builder.Property(t => t.Degree).HasMaxLength(100);

        builder.Property(t => t.Description).IsRequired();
        builder.Property(t => t.Description).HasMaxLength(250);

        builder.ToTable("Testimonials");

        builder.HasData(
            new Testimonial
            {
                Id = 1,
                FullName = "Berkay Akar",
                Degree = "Bilgisayar Mühendisi",
                Description = "\"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book\"",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Testimonial
            {
                Id = 2,
                FullName = "Nihat Ovalıoğlu",
                Degree = "Unity Developer",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            });
    }
}