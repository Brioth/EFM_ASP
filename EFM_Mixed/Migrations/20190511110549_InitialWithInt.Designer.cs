﻿// <auto-generated />
using System;
using EFM_Mixed.Persistence.SQL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFM_Mixed.Migrations
{
    [DbContext(typeof(SQLDbContext))]
    [Migration("20190511110549_InitialWithInt")]
    partial class InitialWithInt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFM_Mixed.Domain.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndDate");

                    b.Property<double>("FTEPerWeek");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("EFM_Mixed.Domain.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EFM_Mixed.Domain.Models.EmployeeAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignmentId");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<double>("FTEPerWeek");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasAlternateKey("EmployeeId", "AssignmentId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("EmployeeAssignments");
                });

            modelBuilder.Entity("EFM_Mixed.Domain.Models.EmployeeAssignment", b =>
                {
                    b.HasOne("EFM_Mixed.Domain.Models.Assignment", "Assignment")
                        .WithMany("EmployeeAssignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFM_Mixed.Domain.Models.Employee", "Employee")
                        .WithMany("EmployeeAssignments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}