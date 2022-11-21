using AutoMapper;
using BT.Domain.Entities;
using BT.Infrastructure.Repositories.Implementation;
using BT.Infrastructure.Repositories.Interfaces;
using BT.Services.Models.EmployeeModels;
using BT.Services.Models.EmployeeTimeSheetModels;
using BT.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Services.Services.Implementation
{
    public class EmployeeTimeSheetService : IEmployeeTimeSheetService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeTimeSheetRepository _timeSheetRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeTimeSheetService(IEmployeeTimeSheetRepository timeSheetRepository, IMapper mapper,
            IEmployeeRepository employeeRepository)
        {
            _timeSheetRepository = timeSheetRepository;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> AddAsync(EmployeeTimeSheetModel timeSheetModel)
        {
            #region Validation
            if (timeSheetModel == null) return false;

            var employee = await _employeeRepository.GetByIdAsync(timeSheetModel.EmployeeId);
            if (employee == null) return false;
            #endregion

            #region Mapping
            var timeSheet = _mapper.Map<EmployeeTimeSheetModel, EmployeeTimeSheet>(timeSheetModel);
            timeSheet.Employee = employee;
            timeSheet.CalculateWorkTimeInMin();
            timeSheet.CalculateBreakTimeInMin();
            #endregion
            #region Database
            var result = await _timeSheetRepository.AddAsync(timeSheet);
            #endregion
            return result;
        }

        public async Task<List<EmployeeTimeSheetModel>> GetAllAsync()
        {
            #region Database
            var result = await _timeSheetRepository.GetAllAsync();
            #endregion
            #region Mapping
            var timeSheets = _mapper.Map<List<EmployeeTimeSheet>, List<EmployeeTimeSheetModel>>(result);
            #endregion
            return timeSheets;
        }

        public async Task<List<EmployeeTimeSheetReportModel>> GetEmployeeBreakHours(TimeSheetFilter filter)
        {
            #region Validation
            if (filter == null) return null;

            var employee = await _employeeRepository.GetByIdAsync(filter.EmployeeId);
            if (employee == null) return null;

            //if (filter.DateFrom.Date > ) return null;
            if (filter.DateTo.Date < filter.DateFrom.Date) return null;
            #endregion

            #region Database
            var result = await _timeSheetRepository.GetAll(x => x.Date.Date >= filter.DateFrom.Date
                                                            && x.Date.Date <= filter.DateTo.Date
                                                            && x.EmployeeId == filter.EmployeeId);
            #endregion

            #region Mapping
            var timeSheets = _mapper.Map<List<EmployeeTimeSheet>, List<EmployeeTimeSheetReportModel>>(result);
            #endregion
            return timeSheets;

        }
    }
}
