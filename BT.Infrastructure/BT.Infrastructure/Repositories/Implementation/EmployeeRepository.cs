using BT.Domain.Entities;
using BT.Infrastructure.Context;
using BT.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BT.Infrastructure.Repositories.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly BreakTrackingContext _dbContext;

        public EmployeeRepository(BreakTrackingContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<bool> AddAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            var result = await _dbContext.SaveChangesAsync();
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var result = await _dbContext.Employees.ToListAsync();
            return result;
        }

        public async Task<Employee> GetByIdAsync(Guid Id)
        {
            var result = _dbContext.Employees.Where(x => x.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
