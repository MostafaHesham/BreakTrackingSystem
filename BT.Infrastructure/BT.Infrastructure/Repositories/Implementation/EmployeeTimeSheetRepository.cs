using BT.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BT.Infrastructure.Repositories.Interfaces;
using BT.Domain.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BT.Infrastructure.Repositories.Implementation
{
    public class EmployeeTimeSheetRepository : IEmployeeTimeSheetRepository
    {
        protected readonly BreakTrackingContext _dbContext;
        public EmployeeTimeSheetRepository(BreakTrackingContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<bool> AddAsync(EmployeeTimeSheet timeSheet)
        {
            _dbContext.TimeSheets.Add(timeSheet);
            var result = await _dbContext.SaveChangesAsync();
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<List<EmployeeTimeSheet>> GetAll(Expression<Func<EmployeeTimeSheet, bool>>? predicate = null)
        {
            var result = await _dbContext.TimeSheets.Where(predicate).Include(x => x.Employee).ToListAsync();
            return result;
        }

        public async Task<List<EmployeeTimeSheet>> GetAllAsync()
        {
            var result = await _dbContext.TimeSheets.Include(x => x.Employee).ToListAsync();
            return result;
        }
    }
}
