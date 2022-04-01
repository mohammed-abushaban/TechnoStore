using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.WareHouse;
using TechnoStore.Infrastructure.Services.WareHouse;
using TechnoStore.Infrastructure.Services.WarehousesProducts;

namespace TechnoStore.Web.Controllers
{
    public class WareHouseController : Controller
    {
        private readonly IWareHouseService _wareHouseService;
        private readonly IWarehousesProductsService _warehousesProductsService;

        public WareHouseController(IWareHouseService wareHouseService, IWarehousesProductsService warehousesProductsService)
        {
            _wareHouseService = wareHouseService;
            _warehousesProductsService = warehousesProductsService;
        }

        //This Action For Show All WareHouses
        public IActionResult Index(string search, int page = 1)
        {
            var model = _wareHouseService.GetAll(search, page);

            ViewBag.Search = search;
            ViewBag.NumOfPages = WareHouseService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            return View(model);
        }
        //This Action For Show page To Add Expenses
        [HttpGet]
        public IActionResult Create()
        {
            //إضافة تحقق قبل فتح الصفحة
            if (_wareHouseService.GetAllCities().Count() <= 0 ||
                _wareHouseService.GetAllUsers().Count() <= 0)
            {
                TempData["msg"] = Messages.NoCategory;
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["CityId"] = new SelectList(_wareHouseService.GetAllCities(), "Id", "Name");
                ViewData["UserID"] = new SelectList(_wareHouseService.GetAllUsers(), "Id", "UserName");
                return View();
            }
        }

        //This Action For Add New Expenses
        [HttpPost]
        public async Task<IActionResult> Create(CreateWareHouseDto dto)
        {

            var result = await _wareHouseService.Save(dto);
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

        //This Action For Show page To Edit WareHouse
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _wareHouseService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            ViewData["CityId"] = new SelectList(_wareHouseService.GetAllCities(), "Id", "Name");
            ViewData["UserID"] = new SelectList(_wareHouseService.GetAllUsers(), "Id", "UserName");
            //جلب وقت الانشاء والمستخدم الذي انشاءه
            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }

        //This Action For Edit WareHouse
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateWareHouseDto dto)
        {
            bool result = await _wareHouseService.Update(dto);
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
            var model = _wareHouseService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            await _wareHouseService.Remove(id);
            TempData["msg"] = Messages.DeleteActon;
            return RedirectToAction("Index");
        }

        //This Action For Details Buy
        public IActionResult Details(int id)
        {
            var model = _wareHouseService.Get(id);
            if (model == null)
            {
                return RedirectToAction("Error", "Settings");
            }
            else
            {
                //int totalQuantity = _warehousesProductsService.GetProductQuantity(id);
                //if(totalQuantity <= 0)
                //{
                //    _productsService.ChangeAvailability(id, false);
                //}
                //else
                //{
                //    _productsService.ChangeAvailability(id, true);
                //}
                int WarehouseQuantity = _warehousesProductsService.GetProductOnOneWarehouseQuantity(id);
                if (WarehouseQuantity <= 0)
                {
                    return View(model);
                }
                else
                {
                    var warehouseProduct = _warehousesProductsService.GetWarehouseDetails(id);
                    ViewBag.warehouseProduct = warehouseProduct;
                    return View(model);
                }
            }
        }
    }
}
