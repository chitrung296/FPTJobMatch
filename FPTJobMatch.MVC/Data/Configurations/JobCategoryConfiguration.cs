using FPTJobMatch.MVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPTJobMatch.MVC.Data.Configurations
{
    public class JobCategoryConfiguration : IEntityTypeConfiguration<JobCategory>
    {
        public void Configure(EntityTypeBuilder<JobCategory> builder)
        {
            builder.Property(cv => cv.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(cv => cv.Description)
                .HasMaxLength(2000);
        }
    }
}
