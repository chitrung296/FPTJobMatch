using FPTJobMatch.MVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPTJobMatch.MVC.Data.Configurations
{
    public class CVConfiguration : IEntityTypeConfiguration<CV>
    {
        public void Configure(EntityTypeBuilder<CV> builder)
        {
            builder.Property(cv => cv.Name)
                .IsRequired()
                .HasMaxLength(75);
        }
    }
}
