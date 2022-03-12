using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.ProductsQuantities;
using TechnoStore.Infrastructure.Services.ProductsQuantities;

namespace TechnoStore.Web.Controllers
{
    public class ProductQuantityController : BaseController
    {
        private readonly IProductsQuantitiesService _productsQuantitiesService;
        public ProductQuantityController(IProductsQuantitiesService productsQuantitiesService)
        {
            _productsQuantitiesService = productsQuantitiesService;
        }

        //This Action For Show All ProductsQuantities
        public IActionResult Index(string search, int page = 1)
        {
            var model = _productsQuantitiesService.GetAll(search,page);

            ViewBag.Search = search;
            ViewBag.NumOfPages = ProductsQuantitiesService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            return View(model);
        }
        //This Action For Show page To Add ProductsQuantity
        [HttpGet]
        public IActionResult Create()
        {
            //إضافة تحقق قبل فتح الصفحة
            if (_productsQuantitiesService.GetAllProducts().Count() <= 0)
            {
                TempData["msg"] = Messages.NoCategory;
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["ProductId"] = new SelectList(_productsQuantitiesService.GetAllProducts(), "Id", "Name");
                return View();
            }
        }

        //This Action For Add New ProductsQuantity
        [HttpPost]
        public async Task<IActionResult> Create(string userId ,CreateProductQuantityDto dto)
        {
            await _productsQuantitiesService.Save(userId,dto);
            TempData["msg"] = Messages.AddAction;
            return RedirectToAction("Index");
        }

        //This Action For Show page To Edit ProductsQuantity
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _productsQuantitiesService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");

            ViewData["ProductId"] = new SelectList(_productsQuantitiesService.GetAllProducts(), "Id", "Name");
            //جلب وقت الانشاء والمستخدم الذي انشاءه
            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }

        //This Action For Edit ProductsQuantity
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, UpdateProductQuantityDto dto)
        {
            await _productsQuantitiesService.Update(userId,dto);
            TempData["msg"] = Messages.EditAction;
            return RedirectToAction("Index");
        }

        //This Action For Soft Delete
        public async Task<IActionResult> Delete(int id)
        {
            var model = _productsQuantitiesService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            await _productsQuantitiesService.Remove(id);
            TempData["msg"] = Messages.DeleteActon;
            return RedirectToAction("Index");
        }

        //This Action For Details ProductsQuantity
        public IActionResult Details(int id)
        {
            var model = _productsQuantitiesService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }

    }
}
