using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.ExpensesCategory;
using TechnoStore.Infostructures.Services.ExpensesCategory;

namespace TechnoStore.Web.Controllers
{
    public class ExpensesCategoryController : BaseController
    {
        private readonly IExpensesCategoryService expensesCategoryService;
        public ExpensesCategoryController(IExpensesCategoryService expensesCategoryService)
        {
            this.expensesCategoryService = expensesCategoryService;
        }

        //This Action For Show All ExpensesCategory
        public IActionResult Index(string search, int page = 1)
        {
            var model = expensesCategoryService.GetAll(search, page);

            ViewBag.Search = search;
            ViewBag.NumOfPages = ExpensesCategoryService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();

            return View(model);
        }
        public IActionResult Test(string search, int page = 1)
        {
            var model = expensesCategoryService.GetAll(search, page);

            ViewBag.Search = search;
            ViewBag.NumOfPages = ExpensesCategoryService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();

            return View(model);
        }


        //This Action For Show page To Add ExpensesCategory
        [HttpGet]
        public IActionResult Create() => View();

        //This Action For Add New ExpensesCategory
        [HttpPost]
        public IActionResult Create(CreateExpensesCategoryDto dto)
        {
            //if (db.BuyTypes.Any(x => x.Type == model.Type && !x.IsDelete))
            //{
            //    TempData["msg"] = Messages.NameExest;
            //    return View(model);
            //}
            expensesCategoryService.Save(dto);
            TempData["msg"] = Messages.AddAction;
            return RedirectToAction("Index");
        }

        //This Action For Show page To Edit ExpensesCategory
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = expensesCategoryService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            //جلب وقت الانشاء والمستخدم الذي انشاءه
            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }

        //This Action For Edit BuyType
        [HttpPost]
        public IActionResult Edit(UpdateExpensesCategoryDto dto)
        {
            expensesCategoryService.Update(dto);
            TempData["msg"] = Messages.EditAction;
            return RedirectToAction("Index");
        }

        //This Action For Soft Delete
        public IActionResult Delete(int id)
        {
            var model = expensesCategoryService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            expensesCategoryService.Remove(id);
            TempData["msg"] = Messages.DeleteActon;
            return RedirectToAction("Index");
        }

        //This Action For Details Buy
        public IActionResult Details(int id)
        {
            var model = expensesCategoryService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }
    }
}
