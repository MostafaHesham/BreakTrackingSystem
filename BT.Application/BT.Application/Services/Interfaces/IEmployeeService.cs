using BT.Domain.Entities;
using BT.Services.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Services.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> AddAsync(EmployeeModel employeeModel);
        Task<EmployeeModel> GetByIdAsync(Guid Id);
        Task<List<EmployeeModel>> GetAllAsync();
    }
}
