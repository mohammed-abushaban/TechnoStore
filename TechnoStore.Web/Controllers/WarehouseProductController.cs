using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.WarehousesProducts;
using TechnoStore.Infrastructure.Services.WarehousesProducts;

namespace TechnoStore.Web.Controllers
{
    public class WarehouseProductController : Controller
    {
        private readonly IWarehousesProductsService _warehousesProductsService;

        public WarehouseProductController(IWarehousesProductsService warehousesProductsService)
        {
            _warehousesProductsService = warehousesProductsService;
        }
        //This Action For Show All WarehouesProducts
        public IActionResult Index(string search, int page = 1)
        {
            var model = _warehousesProductsService.GetAll(search, page);
            ViewBag.Search = search;
            ViewBag.NumOfPages = WarehousesProductsService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();


            ViewData["ProductId"] = new SelectList(_warehousesProductsService.GetAllProducts(), "Id", "Name");
            ViewData["WarehouseId"] = new SelectList(_warehousesProductsService.GetAllWarehoues(), "Id", "Name");
            return View(model);
        }
        //This Action For Show page To Add WarehouesProduct
        [HttpGet]
        public IActionResult Create()
        {
            //إضافة تحقق قبل فتح الصفحة
            if (_warehousesProductsService.GetAllProducts().Count() <= 0 ||
                _warehousesProductsService.GetAllWarehoues().Count() <= 0)
            {
                TempData["msg"] = Messages.NoCategory;
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["ProductId"] = new SelectList(_warehousesProductsService.GetAllProducts(), "Id", "Name");
                ViewData["WarehouseId"] = new SelectList(_warehousesProductsService.GetAllWarehoues(), "Id", "Name");
                return View();
            }
        }

        //This Action For Add New WarehouesProduct
        [HttpPost]
        public async Task<IActionResult> Create(string userId, CreateWarehouseProductDto dto , IFormFile image)
        {

            await _warehousesProductsService.Save(userId, dto, image);
            TempData["msg"] = Messages.AddAction;
            return RedirectToAction("Index");
        }

        //This Action For Show page To Edit WarehouesProduct
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _warehousesProductsService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");

            ViewData["ProductId"] = new SelectList(_warehousesProductsService.GetAllProducts(), "Id", "Name");
            ViewData["WarehouseId"] = new SelectList(_warehousesProductsService.GetAllWarehoues(), "Id", "Name");
            //جلب وقت الانشاء والمستخدم الذي انشاءه
            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }

        //This Action For Edit WarehouesProduct
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, UpdateWarehouseProductDto dto, IFormFile image)
        {
            await _warehousesProductsService.Update(userId, dto, image);
            TempData["msg"] = Messages.EditAction;
            return RedirectToAction("Index");
        }

        //This Action For Soft Delete
        public async Task<IActionResult> Delete(int id)
        {
            var model = _warehousesProductsService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            await _warehousesProductsService.Remove(id);
            TempData["msg"] = Messages.DeleteActon;
            return RedirectToAction("Index");
        }

        //This Action For Details WarehouesProduct
        public IActionResult Details(int id)
        {
            var model = _warehousesProductsService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }

    }
}
