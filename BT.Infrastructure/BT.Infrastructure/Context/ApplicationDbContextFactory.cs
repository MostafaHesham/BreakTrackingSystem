using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Infrastructure.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<BreakTrackingContext>
    {
        public BreakTrackingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BreakTrackingContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Initial Catalog=BreakTrackDB;Trusted_Connection=True;");

            return new BreakTrackingContext(optionsBuilder.Options);
        }
    }
}
