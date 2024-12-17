using FPTJobMatch.MVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPTJobMatch.MVC.Data.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            
            builder.Property(job => job.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(job => job.CompanyName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(job => job.Location)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(job => job.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(job => job.Requirements)
                .HasMaxLength(2000);

            builder.Property(job => job.ImagePath)
                .HasMaxLength(500); 
        }
    }
}
