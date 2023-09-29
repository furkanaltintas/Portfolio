using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities.Concrete;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Configurations;

public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
{
    public void Configure(EntityTypeBuilder<Resume> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedOnAdd();

        builder.Property(r => r.Title).IsRequired();
        builder.Property(r => r.Title).HasMaxLength(100);

        builder.Property(r => r.SubTitle).IsRequired();
        builder.Property(r => r.SubTitle).HasMaxLength(100);

        builder.Property(r => r.DateRange).IsRequired();
        builder.Property(r => r.DateRange).HasMaxLength(20);

        builder.Property(r => r.CreatedDate).IsRequired();
        builder.Property(r => r.IsActive).IsRequired();
        builder.Property(r => r.IsDeleted).IsRequired();

        builder.ToTable("Resumes");

        builder.HasData(new Resume
        {
            Id = 1,
            Title = "Bilgisayar Programcılığı",
            SubTitle = "Düzce Üniversitesi",
            DateRange = "2019 - 2021",
            CreatedDate = DateTime.Now,
            IsActive = true,
            IsDeleted = false
        });
    }
}