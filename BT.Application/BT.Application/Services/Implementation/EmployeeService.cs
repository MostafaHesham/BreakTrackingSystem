using AutoMapper;
using BT.Domain.Entities;
using BT.Infrastructure.Repositories.Interfaces;
using BT.Services.Models.EmployeeModels;
using BT.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Services.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(EmployeeModel employeeModel)
        {
            #region Validation
            if (employeeModel == null) return false;
            #endregion

            #region Mapping
            var emp = _mapper.Map<EmployeeModel, Employee>(employeeModel);
            #endregion
            #region Database
            var result = await _employeeRepository.AddAsync(emp);
            #endregion
            return result;
        }

        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            #region Database
            var employeeList = await _employeeRepository.GetAllAsync();
            #endregion
            #region Mapping
            var employeeModelList = _mapper.Map<List<Employee>, List<EmployeeModel>>(employeeList);
            #endregion
            return employeeModelList;
        }

        public async Task<EmployeeModel> GetByIdAsync(Guid Id)
        {
            #region Database
            var employee = await _employeeRepository.GetByIdAsync(Id);
            #endregion
            #region Mapping
            var employeeModel = _mapper.Map<Employee, EmployeeModel>(employee);
            #endregion
            return employeeModel;

        }
    }
}
