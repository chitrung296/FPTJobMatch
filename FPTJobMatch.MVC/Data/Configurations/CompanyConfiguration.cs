using FPTJobMatch.MVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPTJobMatch.MVC.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(cv => cv.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(cv => cv.Address)
                .HasMaxLength(250);
            builder.Property(cv => cv.Email)
                .HasMaxLength(100);
            builder.Property(cv => cv.Hotline)
                .HasMaxLength(15);

            builder.Property(cv => cv.TaxNumber)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
