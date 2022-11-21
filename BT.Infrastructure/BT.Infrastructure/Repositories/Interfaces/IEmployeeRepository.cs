using BT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Infrastructure.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<bool> AddAsync(Employee employee);
        Task<Employee> GetByIdAsync(Guid Id);
        Task<List<Employee>> GetAllAsync();
    }
}
