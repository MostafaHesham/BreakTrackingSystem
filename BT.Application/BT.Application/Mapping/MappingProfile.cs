using AutoMapper;
using BT.Domain.Entities;
using BT.Services.Enums;
using BT.Services.Models.EmployeeModels;
using BT.Services.Models.EmployeeTimeSheetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeModel, Employee>().ReverseMap();

            CreateMap<EmployeeTimeSheetModel, EmployeeTimeSheet>()
                .ForMember(dest => dest.DateSubmitted, opts => opts.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Date, opts => opts.MapFrom(src => src.Date.Date))
                .ReverseMap();

            CreateMap<EmployeeTimeSheet, EmployeeTimeSheetReportModel>()
                .ForMember(dest => dest.EmployeeName, opts => opts.MapFrom(src => src.Employee.FullName))
                .ForMember(dest => dest.TotalBreakMins, opts => opts.MapFrom(src => src.TotalBreakInMin))
                .ForMember(dest => dest.TotalWorkHours, opts => opts.MapFrom(src => TimeSpan.FromMinutes(src.TotalWorkInMin).Hours))
                .ForMember(dest => dest.EmployeePosition, opts => opts.MapFrom(src => Enum.GetName(typeof(EmployeeType), src.Employee.Position)));
        }
    }
}
