using BT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Infrastructure.Context
{
    public class BreakTrackingContext : DbContext
    {
        protected BreakTrackingContext() 
        {

        }
        public BreakTrackingContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeTimeSheet> TimeSheets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(t => t.TimeSheets)
                .WithOne(t => t.Employee)
                .HasForeignKey(t => t.EmployeeId);

            modelBuilder.Entity<EmployeeTimeSheet>()
                .HasOne(t => t.Employee)
                .WithMany(t => t.TimeSheets)
                .HasForeignKey(t => t.EmployeeId);
        }
    }
}
