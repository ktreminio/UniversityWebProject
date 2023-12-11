﻿// <auto-generated />
using System;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(UniversityContext))]
    [Migration("20231210143304_InitialUniversityDB")]
    partial class InitialUniversityDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kevin.Treminio.University.Service.Domain.Entities.Course", b =>
                {
                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<byte>("Credits")
                        .HasColumnType("tinyint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CourseId");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("Kevin.Treminio.University.Service.Domain.Entities.CourseAssignment", b =>
                {
                    b.Property<Guid>("InstructorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InstructorId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseAssignment", (string)null);
                });

            modelBuilder.Entity("Kevin.Treminio.University.Service.Domain.Entities.Enrollment", b =>
                {
                    b.Property<Guid>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Grade")
                        .HasColumnType("decimal(3, 2)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollment", (string)null);
                });

            modelBuilder.Entity("Kevin.Treminio.University.Service.Domain.Entities.Instructor", b =>
                {
                    b.Property<Guid>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructor", (string)null);
                });

            modelBuilder.Entity("Kevin.Treminio.University.Service.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("StudentId");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("Kevin.Treminio.University.Service.Domain.Entities.CourseAssignment", b =>
                {
                    b.HasOne("Kevin.Treminio.University.Service.Domain.Entities.Course", "Course")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kevin.Treminio.University.Service.Domain.Entities.Instructor", "Instructor")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Kevin.Treminio.University.Service.Domain.Entities.Enrollment", b =>
                {
                    b.HasOne("Kevin.Treminio.University.Service.Domain.Entities.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kevin.Treminio.University.Service.Domain.Entities.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Kevin.Treminio.University.Service.Domain.Entities.Course", b =>
                {
                    b.Navigation("CourseAssignments");

                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("Kevin.Treminio.University.Service.Domain.Entities.Instructor", b =>
                {
                    b.Navigation("CourseAssignments");
                });

            modelBuilder.Entity("Kevin.Treminio.University.Service.Domain.Entities.Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}