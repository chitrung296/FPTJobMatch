﻿// <auto-generated />
using System;
using FPTJobMatch.MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FPTJobMatch.MVC.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241216022252_update")]
    partial class update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FPTJobMatch.MVC.Data.Entities.CV", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("JobSeekerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("Id");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("CVs");
                });

            modelBuilder.Entity("FPTJobMatch.MVC.Data.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Hotline")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("FPTJobMatch.MVC.Data.Entities.CompanyJobDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Requirements")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("JobId");

                    b.ToTable("CompanyJobDetails");
                });

            modelBuilder.Entity("FPTJobMatch.MVC.Data.Entities.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("JobCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("Postion")
                        .HasColumnType("int");

                    b.Property<string>("Requirements")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("Id");

                    b.HasIndex("JobCategoryId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("FPTJobMatch.MVC.Data.Entities.JobCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("JobCategories");
                });

            modelBuilder.Entity("FPTJobMatch.MVC.Data.Entities.JobSeeker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Occupation")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("JobSeekers");
                });

            modelBuilder.Entity("FPTJobMatch.MVC.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Occupation")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FPTJobMatch.MVC.Data.Entities.CV", b =>
                {
                    b.HasOne("FPTJobMatch.MVC.Data.Entities.JobSeeker", "JobSeeker")
                        .WithMany("CVs")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("FPTJobMatch.MVC.Data.Entities.CompanyJobDetail", b =>
                {
                    b.HasOne("FPTJobMatch.MVC.Data.Entities.Company", "Company")
                        .WithMany("CompanyJobDetails")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FPTJobMatch.MVC.Data.Entities.Job", "Job")
                        .WithMany("CompanyJobDetails")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("FPTJobMatch.MVC.Data.Entities.Job", b =>
                {
                    b.HasOne("FPTJobMatch.MVC.Data.Entities.JobCategory", "JobCategory")
                        .WithMany("Jobs")
                        .HasForeignKey("JobCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobCategory");
                });

            modelBuilder.Entity("FPTJobMatch.MVC.Data.Entities.Company", b =>
                {
                    b.Navigation("CompanyJobDetails");
                });

            modelBuilder.Entity("FPTJobMatch.MVC.Data.Entities.Job", b =>
                {
                    b.Navigation("CompanyJobDetails");
                });

            modelBuilder.Entity("FPTJobMatch.MVC.Data.Entities.JobCategory", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("FPTJobMatch.MVC.Data.Entities.JobSeeker", b =>
                {
                    b.Navigation("CVs");
                });
#pragma warning restore 612, 618
        }
    }
}
