using FPTJobMatch.MVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPTJobMatch.MVC.Data.Configurations
{
    public class CompanyJobDetailConfiguration : IEntityTypeConfiguration<CompanyJobDetail>
    {
        public void Configure(EntityTypeBuilder<CompanyJobDetail> builder)
        {
            builder.Property(cv => cv.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(cv => cv.Requirements)
                .HasMaxLength(2000);
            
        }
    }
}
