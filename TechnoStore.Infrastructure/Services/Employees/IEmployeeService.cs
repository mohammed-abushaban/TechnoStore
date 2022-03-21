using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Employees;
using TechnoStore.Core.Enums;
using TechnoStore.Core.ViewModel.Employees;

namespace TechnoStore.Infrastructure.Services.Employees
{
    public interface IEmployeeService
    {
        List<EmployeeVm> GetAll(string search, int page, Gender? gender);
        List<EmployeeVm> GetAll();
        EmployeeVm Get(int id);
        Task<bool> Save(CreateEmployeeDto dto);
        Task<int> Update(UpdateEmployeeDto dto);
        Task<int> Remove(int id);
    }
}
