using FPTJobMatch.MVC.Data.Configurations;
using FPTJobMatch.MVC.Data.Entities;
using FPTJobMatch.MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;

namespace FPTJobMatch.MVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(b => b.FullName)
                .IsRequired()
                .HasMaxLength(75);

            modelBuilder.Entity<User>()
                .Property(b => b.Name)
                .HasMaxLength(25);

            modelBuilder.Entity<User>()
                .Property(b => b.Phone)
                .HasMaxLength(15);

            modelBuilder.Entity<User>()
                .Property(b => b.Email)
                .HasMaxLength(50);

            modelBuilder.ApplyConfiguration(new JobSeekerConfiguration());
            modelBuilder.ApplyConfiguration(new CVConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyJobDetailConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new JobCategoryConfiguration());
        }

        public DbSet<User> Users { get; set; }

        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyJobDetail> CompanyJobDetails { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }

    }
}
