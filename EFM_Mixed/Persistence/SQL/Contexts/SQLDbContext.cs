using EFM_Mixed.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFM_Mixed.Persistence.SQL.Contexts
{
    public class SQLDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<EmployeeAssignment> EmployeeAssignments { get; set; }



        public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>()
                .HasIndex(e => e.Name).IsUnique();

            builder.Entity<Assignment>()
                .HasIndex(a => a.Name).IsUnique();
            builder.Entity<Assignment>()
                .Property(a => a.StartDate).IsRequired();
            builder.Entity<Assignment>()
                .Property(a => a.FTEPerWeek).IsRequired();

            builder.Entity<EmployeeAssignment>()
                .HasAlternateKey(ea => new { ea.EmployeeId, ea.AssignmentId });
            builder.Entity<EmployeeAssignment>()
                .Property(ea => ea.StartDate).IsRequired();
            builder.Entity<EmployeeAssignment>()
                .Property(ea => ea.FTEPerWeek).IsRequired();

        }
    }
}
