using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Expenses;
using TechnoStore.Infostructures.Services.ExpensesCategories;
using TechnoStore.Infrastructure.Services.Expenses;

namespace TechnoStore.Web.Controllers
{
    public class ExpensesController : BaseController
    {
        private readonly IExpensesService _expensesService;
        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        //This Action For Show All Expenses
        public IActionResult Index(string search, int page = 1)
        {
            var model = _expensesService.GetAll(search, page);
            
            ViewBag.Search = search;
            ViewBag.NumOfPages = ExpensesService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            ViewBag.sum = model.ToList().Sum(x => x.Price);

            return View(model);
        }
        //This Action For Show page To Add Expenses
        [HttpGet]
        public IActionResult Create()
        {
            //إضافة تحقق قبل فتح الصفحة
            if(_expensesService.GetAllExpensesCategories().Count() <= 0)
            {
                TempData["msg"] = Messages.NoCategory;
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["ExpensesCategoryId"] = new SelectList(_expensesService.GetAllExpensesCategories(), "Id", "Name");
                return View();
            }
        }

        //This Action For Add New Expenses
        [HttpPost]
        public async Task<IActionResult> Create(CreateExpensesDto dto)
        {

            await _expensesService.Save(dto);
            TempData["msg"] = Messages.AddAction;
            return RedirectToAction("Index");
        }

        //This Action For Show page To Edit Expenses
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _expensesService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");

            ViewData["ExpensesCategoryId"] = new SelectList(_expensesService.GetAllExpensesCategories(), "Id", "Name");
            //جلب وقت الانشاء والمستخدم الذي انشاءه
            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }

        //This Action For Edit Expenses
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateExpensesDto dto)
        {
            await _expensesService.Update(dto);
            TempData["msg"] = Messages.EditAction;
            return RedirectToAction("Index");
        }

        //This Action For Soft Delete
        public async Task<IActionResult> Delete(int id)
        {
            var model = _expensesService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            await _expensesService.Remove(id);
            TempData["msg"] = Messages.DeleteActon;
            return RedirectToAction("Index");
        }

        //This Action For Details Buy
        public IActionResult Details(int id)
        {
            var model = _expensesService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }
    }
}
