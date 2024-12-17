using FPTJobMatch.MVC.Data.Entities;
using FPTJobMatch.MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace FPTJobMatch.MVC.Data.Configurations
{
    public class JobSeekerConfiguration : IEntityTypeConfiguration<JobSeeker>
    {
        public void Configure(EntityTypeBuilder<JobSeeker> builder)
        {
            builder
                .Property(b => b.FullName)
            .IsRequired()
                .HasMaxLength(75);

            builder
            .Property(b => b.Name)
                .HasMaxLength(25);

            builder
            .Property(b => b.Phone)
                .HasMaxLength(15);

            builder
                .Property(b => b.Email)
                .HasMaxLength(50);
        }
    }
}
