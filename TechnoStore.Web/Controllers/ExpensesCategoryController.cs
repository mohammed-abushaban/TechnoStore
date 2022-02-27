using Microsoft.AspNetCore.Mvc;
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
        private readonly IExpensesCategoryService expensesCategoryService;
        private readonly IExpensesService expensesService;
        public ExpensesCategoryController(IExpensesCategoryService expensesCategoryService,
                                          IExpensesService expensesService)
        {
            this.expensesCategoryService = expensesCategoryService;
            this.expensesService = expensesService;
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

        //This Action For Show page To Add ExpensesCategory
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //This Action For Add New ExpensesCategory
        [HttpPost]
        public async Task<IActionResult> Create(CreateExpensesCategoryDto dto)
        {
            if (expensesCategoryService.GetList().Any(x => x.Name == dto.Name))
            {
                TempData["msg"] = Messages.NameExest;
                return View();
            }
            await expensesCategoryService.Save(dto);
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

        //This Action For Edit ExpensesCategory
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateExpensesCategoryDto dto)
        {
            await expensesCategoryService.Update(dto);
            TempData["msg"] = Messages.EditAction;
            return RedirectToAction("Index");
        }

        //This Action For Soft Delete
        public async Task<IActionResult> Delete(int id)
        {
            var model = expensesCategoryService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            foreach (var item in expensesService.GetList())
            {
                if (model.Id == item.ExpensesCategoryId)
                {
                    TempData["msg"] = Messages.NoDeleteCategory;
                    return RedirectToAction("Index");
                }
            }
            await expensesCategoryService.Remove(id);
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
