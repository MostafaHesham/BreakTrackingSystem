using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Services.Models.EmployeeTimeSheetModels
{
    public class EmployeeTimeSheetReportModel
    {
        public string EmployeeName { get; set; }
        public string EmployeePosition { get; set; }
        public int TotalWorkHours { get; set; }
        public int TotalBreakMins { get; set; }
        public string Date { get; set; }
    }
}
