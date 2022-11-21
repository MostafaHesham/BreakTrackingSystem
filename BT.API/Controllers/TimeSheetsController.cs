using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BT.Domain.Entities;
using BT.Infrastructure.Context;
using BT.Services.Services.Interfaces;
using BT.Services.Models.EmployeeTimeSheetModels;

namespace BT.Web.Controllers
{
    public class TimeSheetsController : Controller
    {
        private readonly IEmployeeTimeSheetService _timeSheetService;
        private readonly IEmployeeService _employeeService;

        public TimeSheetsController(IEmployeeTimeSheetService timeSheetService, IEmployeeService employeeService)
        {
            _timeSheetService = timeSheetService;
            _employeeService = employeeService;
        }

        // GET: TimeSheets
        public async Task<IActionResult> Index()
        {
            var timeSheetList = await _timeSheetService.GetAllAsync();
            return View(timeSheetList);
        }

        // GET: TimeSheets/Create
        public async Task<IActionResult> Create()
        {
            ViewData["EmployeeId"] = new SelectList(await _employeeService.GetAllAsync(), "Id", "FirstName");
            return View();
        }

        // POST: TimeSheets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,Date,InTime,OutTime,CalculateOverTime,IsNightShift")] EmployeeTimeSheetModel employeeTimeSheet)
        {
            if (ModelState.IsValid)
            {
                await _timeSheetService.AddAsync(employeeTimeSheet);

                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(await _employeeService.GetAllAsync(), "Id", "FirstName", employeeTimeSheet.EmployeeId);
            return View(employeeTimeSheet);
        }

        // GET: TimeSheets/BreakReportFilter
        public async Task<IActionResult> BreakReportFilter()
        {
            ViewData["EmployeeId"] = new SelectList(await _employeeService.GetAllAsync(), "Id", "FirstName");
            return View();
        }

        // POST: TimeSheets/BreakReportFilter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BreakReportFilter([Bind("DateFrom,DateTo,EmployeeId")] TimeSheetFilter timeSheetFilter)
        {
            if (ModelState.IsValid)
            {
                var result = await _timeSheetService.GetEmployeeBreakHours(timeSheetFilter);

                return View("BreakReportResult", result);
            }
            ViewData["EmployeeId"] = new SelectList(await _employeeService.GetAllAsync(), "Id", "FirstName", timeSheetFilter.EmployeeId);
            return View(timeSheetFilter);
        }
    }
}
