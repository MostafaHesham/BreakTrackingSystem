using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Services.Models.EmployeeTimeSheetModels
{
    public class TimeSheetFilter
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
