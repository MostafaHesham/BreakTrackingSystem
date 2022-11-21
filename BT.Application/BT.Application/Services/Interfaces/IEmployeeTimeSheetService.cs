using BT.Domain.Entities;
using BT.Services.Models.EmployeeTimeSheetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Services.Services.Interfaces
{
    public interface IEmployeeTimeSheetService
    {
        Task<bool> AddAsync(EmployeeTimeSheetModel timeSheet);
        Task<List<EmployeeTimeSheetReportModel>> GetEmployeeBreakHours(TimeSheetFilter filter);
        Task<List<EmployeeTimeSheetModel>> GetAllAsync();
    }
}
