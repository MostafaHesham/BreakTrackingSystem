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
using BT.Services.Models.EmployeeModels;

namespace BT.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly BreakTrackingContext _context;
        public EmployeesController(BreakTrackingContext context, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var EmpList = await _employeeService.GetAllAsync();
              return View(EmpList);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,FullName,HireDate,Gender,Position")] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                var IsSuccess =  await _employeeService.AddAsync(employee);
                if (IsSuccess)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
    }
}
