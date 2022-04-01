 using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.ExpensesCategories;
using TechnoStore.Infostructures.Services.ExpensesCategories;
using TechnoStore.Infrastructure.Services.Expenses;

namespace TechnoStore.Web.Controllers
{
    public class ExpensesCategoryController : BaseController
    {
        private readonly IExpensesCategoryService _expensesCategoryService;
        private readonly IExpensesService _expensesService;
        public ExpensesCategoryController(IExpensesCategoryService expensesCategoryService,
                                          IExpensesService expensesService)
        {
            _expensesCategoryService = expensesCategoryService;
            _expensesService = expensesService;
        }

        //This Action For Show All ExpensesCategoreis
        public IActionResult Index(string search, int page = 1)
        {
            var model = _expensesCategoryService.GetAll(search, page);

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
        public async Task<IActionResult> Create(CreateExpensesCategoryDto dto)
        {

            var result = await _expensesCategoryService.Save(dto);
            if(result == false)
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

        //This Action For Show page To Edit ExpensesCategory
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _expensesCategoryService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            //جلب وقت الانشاء والمستخدم الذي انشاءه
            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }

        //This Action For Edit ExpensesCategory
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateExpensesCategoryDto dto)
        {
            bool result = await _expensesCategoryService.Update(dto);
            if (result == false)
            {
                TempData["msg"] = Messages.NameExest;
                return View();
            }
            else
            {
                TempData["msg"] = Messages.EditAction;
                return RedirectToAction("Index");
            }

        }

        //This Action For Soft Delete
        public async Task<IActionResult> Delete(int id) 
        {
            var model = _expensesCategoryService.Get(id);
            if (model == null)
            {
                return RedirectToAction("Error", "Settings");
            }
            else
            {
                var result = await _expensesCategoryService.Remove(id);
                if (result == false)
                {
                    TempData["msg"] = Messages.NoDeleteCategory;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["msg"] = Messages.DeleteActon;
                    return RedirectToAction("Index");
                }
            }
        }

        //This Action For Details Buy
        public IActionResult Details(int id)
        {
            var model = _expensesCategoryService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }
    }
}
