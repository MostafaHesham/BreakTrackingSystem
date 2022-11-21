using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Domain.Entities
{
    public class EmployeeTimeSheet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public int TotalWorkInMin { get; set; }
        public int TotalBreakInMin { get; set; }
        public int TotalOverTimeInMin { get; set; }
        public bool CalculateOverTime { get; set; }
        public DateTime DateSubmitted { get; set; }
        public bool IsNightShift { get; set; }
        public virtual Employee Employee { get; set; }

    }
    public static class MyExtensions
    {
        public static void CalculateWorkTimeInMin(this EmployeeTimeSheet timeSheet)
        {
            if (timeSheet.OutTime.TimeOfDay > timeSheet.InTime.TimeOfDay)
            {
                TimeSpan t = timeSheet.OutTime.TimeOfDay - timeSheet.InTime.TimeOfDay;
                timeSheet.TotalWorkInMin = Convert.ToInt32(TimeSpan.FromHours(t.Hours).TotalMinutes);
            }
        }

        public static void CalculateBreakTimeInMin(this EmployeeTimeSheet timeSheet)
        {
            if (timeSheet.TotalWorkInMin > 0)
            {
                int WorkHoursInHours = TimeSpan.FromMinutes(timeSheet.TotalWorkInMin).Hours;
                if (timeSheet.Employee.Position == 0) //Employee
                {
                    timeSheet.TotalBreakInMin = WorkHoursInHours * 10;
                    var countOf4 = WorkHoursInHours / 4;
                    timeSheet.TotalBreakInMin += (WorkHoursInHours / 4) * 10;
                }
                else //Manager
                {
                    timeSheet.TotalBreakInMin = WorkHoursInHours * 15;
                }

                if (timeSheet.IsNightShift) // Night shift extra break
                {
                    var countOf2 = WorkHoursInHours / 2;
                    timeSheet.TotalBreakInMin += (WorkHoursInHours / 2) * 10;
                }
            }
        }
    }
}
