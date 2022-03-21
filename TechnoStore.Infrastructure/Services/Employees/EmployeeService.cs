using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Employees;
using TechnoStore.Core.Enums;
using TechnoStore.Core.ViewModel.Employees;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infrastructure.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        DateTime date = DateTime.Now;
        public static double NumOfPages;

        public EmployeeService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        //Get All Employees
        public List<EmployeeVm> GetAll(string search, int page, Gender? gender)
        {
            var NumOfExpCat = _db.Employees
                .Count(x => x.Name.Contains(search)
                || x.Phone.Contains(search) || string.IsNullOrEmpty(search)
                && (x.Gender == gender || gender == null));

            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page20 + 0.0));
            var Skip = (page - 1) * NumPages.page20;
            var Take = NumPages.page20;

            var employees = _db.Employees
                .Where(x => x.Name.Contains(search)
                || x.Phone.Contains(search) || string.IsNullOrEmpty(search)
                && (x.Gender == gender || gender == null))
                .Skip(Skip).Take(Take).ToList();

            return _mapper.Map<List<EmployeeVm>>(employees);
        }

        //Get All To List
        public List<EmployeeVm> GetAll()
        {
            var employees = _db.Employees.ToList();
            return _mapper.Map<List<EmployeeVm>>(employees);
        }

        //Get Employee
        public EmployeeVm Get(int id)
        {
            var employees = _db.Employees.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<EmployeeVm>(employees);
        }

        //Create A New Employee
        public async Task<bool> Save(CreateEmployeeDto dto)
        {
            var employee = _mapper.Map<EmployeeDbEntity>(dto);
            employee.CreateAt = date;
            employee.CreateBy = "Test";
            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
            return true;
        }


        //Update Any Employee
        public async Task<int> Update(UpdateEmployeeDto dto)
        {
            var employee = _mapper.Map<EmployeeDbEntity>(dto);
            employee.UpdateAt = date;
            employee.UpdateBy = "Test";
            _db.Employees.Update(employee);
            await _db.SaveChangesAsync();
            return employee.Id;
        }

        //Delete Any Employee
        public async Task<int> Remove(int id)
        {
            var employee = _db.Employees.SingleOrDefault(x => x.Id == id);
            employee.IsDelete = true;
            _db.Employees.Update(employee);
            await _db.SaveChangesAsync();
            return employee.Id;
        }
    }
}
