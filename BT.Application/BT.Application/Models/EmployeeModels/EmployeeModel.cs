using BT.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Services.Models.EmployeeModels
{
    public class EmployeeModel
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        private string _fullName;
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = FirstName + " " + MiddleName + " " + LastName;
            }
        }
        public DateTime HireDate { get; set; }
        public GenderEnum Gender { get; set; }
        public EmployeeType Position { get; set; } // 0 => employee || 1 => Manager
    }
}
