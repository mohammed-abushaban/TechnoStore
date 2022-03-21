using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Employees;
using TechnoStore.Core.Enums;
using TechnoStore.Infrastructure.Services.Employees;

namespace TechnoStore.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //This Action For Show All Employees
        public IActionResult Index(string search, Gender? gender, int page = 1)
        {
            var model = _employeeService.GetAll(search, page, gender);

            ViewBag.Search = search;
            ViewBag.gender = gender;
            ViewBag.NumOfPages = EmployeeService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            return View(model);
        }

        //This Action For Show page To Add Employee
        [HttpGet]
        public IActionResult Create() => View();

        //This Action For Add New Employee
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto dto)
        {
            var result = await _employeeService.Save(dto);
            if (result == false)
            {
                TempData["msg"] = Messages.NameExest;
                return View();
            }
            else
            {
                TempData["msg"] = Messages.AddAction;
                return RedirectToAction("Index");
            }
        }

        //This Action For Show page To Edit Employee
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _employeeService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }

        //This Action For Edit Employee
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateEmployeeDto dto)
        {
            await _employeeService.Update(dto);
            TempData["msg"] = Messages.EditAction;
            return RedirectToAction("Index");
        }

        //This Action For Soft Delete
        public async Task<IActionResult> Delete(int id)
        {
            var model = _employeeService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            await _employeeService.Remove(id);
            TempData["msg"] = Messages.DeleteActon;
            return RedirectToAction("Index");
        }

        //This Action For Details Buy
        public IActionResult Details(int id)
        {
            var model = _employeeService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }
    }
}
