using BT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BT.Infrastructure.Repositories.Interfaces
{
    public interface IEmployeeTimeSheetRepository
    {
        Task<bool> AddAsync(EmployeeTimeSheet timeSheet);
        Task<List<EmployeeTimeSheet>> GetAll(Expression<Func<EmployeeTimeSheet, bool>>? predicate = null);
        Task<List<EmployeeTimeSheet>> GetAllAsync();
    }
}
