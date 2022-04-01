using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.SubCategories;
using TechnoStore.Infrastructure.Services.Categories;
using TechnoStore.Infrastructure.Services.Products;
using TechnoStore.Infrastructure.Services.SubCategories;

namespace TechnoStore.Web.Controllers
{
    public class SubCategoryController : BaseController
    {
        private readonly ISubCategoriesService _subCategoriesService;
        private readonly IProductsService _productsService;

        public SubCategoryController(ISubCategoriesService subCategoriesService, IProductsService productsService)
        {
            _subCategoriesService = subCategoriesService;
            _productsService = productsService;
        }

        //This Action For Show All SubCategories
        public IActionResult Index(string search, int page = 1)
        {
            var model = _subCategoriesService.GetAll(search, page);

            ViewBag.Search = search;
            ViewBag.NumOfPages = SubCategoriesService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            return View(model);
        }
        //This Action For Show page To Add SubCategory
        [HttpGet]
        public IActionResult Create()
        {
            //إضافة تحقق قبل فتح الصفحة
            if (_subCategoriesService.GetAllCategories().Count() <= 0)
            {
                TempData["msg"] = Messages.NoCategory;
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["CategoryId"] = new SelectList(_subCategoriesService.GetAllCategories(), "Id", "Name");
                return View();
            }
        }

        //This Action For Add New SubCategory
        public async Task<IActionResult> Create(string userId, CreateSubCategoryDto dto)
        {

            var result = await _subCategoriesService.Save(userId, dto);
            if (result == false)
            {
                TempData["msg"] = Messages.NameExest;
                ViewData["CategoryId"] = new SelectList(_subCategoriesService.GetAllCategories(), "Id", "Name");
                return View();
            }
            else
            {
                TempData["msg"] = Messages.AddAction;
                return RedirectToAction("Index");
            }
        }

        //This Action For Show page To Edit SubCategory
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _subCategoriesService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");

            ViewData["CategoryId"] = new SelectList(_subCategoriesService.GetAllCategories(), "Id", "Name");

            //جلب وقت الانشاء والمستخدم الذي انشاءه
            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }
        //This Action For Edit SubCategory
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, UpdateSubCategoryDto dto)
        {
            bool result = await _subCategoriesService.Update(userId, dto);
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
            var model = _subCategoriesService.Get(id);
            if (model == null)
            {
                return RedirectToAction("Error", "Settings");
            }
            else
            {
                var result = await _subCategoriesService.Remove(id);
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
        //This Action For Details SubCategory
        public IActionResult Details(int id)
        {
            var model = _subCategoriesService.Get(id);
            if (model == null)
            {
                return RedirectToAction("Error", "Settings");
            }
            else
            {
                var products = _productsService.GetForSubCategory(id);
                ViewBag.products = products;
                return View(model);
            }
        }

    }
}
