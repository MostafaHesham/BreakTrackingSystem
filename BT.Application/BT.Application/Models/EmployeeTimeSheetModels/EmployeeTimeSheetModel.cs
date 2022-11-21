using BT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Services.Models.EmployeeTimeSheetModels
{
    public class EmployeeTimeSheetModel
    {
        public Guid? Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public int TotalWorkInMin { get; set; }
        public int TotalBreakInMin { get; set; }
        public int TotalOverTimeInMin { get; set; }
        public bool CalculateOverTime { get; set; }
        public bool IsNightShift { get; set; }
        public Employee Employee { get; set; }

    }
}
