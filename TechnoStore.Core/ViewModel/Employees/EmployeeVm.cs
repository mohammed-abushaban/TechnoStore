using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Enums;

namespace TechnoStore.Core.ViewModel.Employees
{
    public class EmployeeVm : BaseVm
    {
        public string Name { get; set; }
        public string NumPerId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime Birth { get; set; }
        public Gender Gender { get; set; }
        public string Career { get; set; }
        public int? GradYear { get; set; }
        public string JobNum { get; set; }
        public int? YearOfExp { get; set; }
        public DateTime? StartWork { get; set; }
        public int? WorkHours { get; set; }
        public int? Salary { get; set; }
    }
}
