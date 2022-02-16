﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Expenses;
using TechnoStore.Infostructures.Services.ExpensesCategory;
using TechnoStore.Infrastructure.Services.Expenses;

namespace TechnoStore.Web.Controllers
{
    public class ExpensesController : BaseController
    {
        private readonly IExpensesService expensesService;
        private readonly IExpensesCategoryService expensesCategoryService;
        public ExpensesController(IExpensesService expensesService , IExpensesCategoryService expensesCategoryService)
        {
            this.expensesService = expensesService;
            this.expensesCategoryService = expensesCategoryService;
        }

        //This Action For Show All Expenses
        public IActionResult Index(string search, int page = 1)
        {
            var model = expensesService.GetAll(search, page);

            ViewBag.Search = search;
            ViewBag.NumOfPages = ExpensesService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            ViewBag.Category = expensesCategoryService.GetList();
            //مجموع المصروفات
            ViewBag.sum = model.ToList().Sum(x => x.Price);

            return View(model);
        }
        //This Action For Show page To Add Expenses
        [HttpGet]
        public IActionResult Create()
        {
            //إضافة تحقق قبل فتح الصفحة
            if(expensesCategoryService.GetList().Count() <= 0)
            {
                TempData["msg"] = Messages.NoCategory;
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["ExpensesCategoryId"] = new SelectList(expensesCategoryService.GetList(), "Id", "Name");
                return View();
            }
        }

        //This Action For Add New Expenses
        [HttpPost]
        public async Task<IActionResult> Create(CreateExpensesDto dto)
        {
            await expensesService.Save(dto);
            TempData["msg"] = Messages.AddAction;
            return RedirectToAction("Index");
        }

        //This Action For Show page To Edit Expenses
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = expensesService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");

            ViewData["ExpensesCategoryId"] = new SelectList(expensesCategoryService.GetList(), "Id", "Name");
            //جلب وقت الانشاء والمستخدم الذي انشاءه
            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }

        //This Action For Edit Expenses
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateExpensesDto dto)
        {
            await expensesService.Update(dto);
            TempData["msg"] = Messages.EditAction;
            return RedirectToAction("Index");
        }

        //This Action For Soft Delete
        public async Task<IActionResult> Delete(int id)
        {
            var model = expensesService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            await expensesService.Remove(id);
            TempData["msg"] = Messages.DeleteActon;
            return RedirectToAction("Index");
        }

        //This Action For Details Buy
        public IActionResult Details(int id)
        {
            var model = expensesService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }
    }
}