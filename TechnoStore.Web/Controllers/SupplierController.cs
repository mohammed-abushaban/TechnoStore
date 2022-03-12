using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Suppliers;
using TechnoStore.Infrastructure.Services.Suppliers;

namespace TechnoStore.Web.Controllers
{
    public class SupplierController : BaseController
    {
        private readonly ISuppliersService _suppliersService;

        public SupplierController(ISuppliersService suppliersService)
        {
            _suppliersService = suppliersService;
        }
        //This Action For Show All Suppliers
        public IActionResult Index(string search, int page = 1)
        {
            var model = _suppliersService.GetAll(search, page);

            ViewBag.Search = search;
            ViewBag.NumOfPages = SuppliersService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            return View(model);
        }

        //This Action For Show page To Add Supplier
        [HttpGet]
        public IActionResult Create() => View();

        //This Action For Add New Shipper
        [HttpPost]
        public async Task<IActionResult> Create(string userId,CreateSupplierDto dto)
        {
            var result = await _suppliersService.Save(userId,dto);
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

        //This Action For Show page To Edit Supplier
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _suppliersService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }

        //This Action For Edit Supplier
        [HttpPost]
        public async Task<IActionResult> Edit(string userId,UpdateSupplierDto dto)
        {
            await _suppliersService.Update(userId,dto);
            TempData["msg"] = Messages.EditAction;
            return RedirectToAction("Index");
        }

        //This Action For Soft Delete
        public async Task<IActionResult> Delete(int id)
        {
            var model = _suppliersService.Get(id);
            if (model == null)
            {
                return RedirectToAction("Error", "Settings");
            }
            else
            {
                var remove = await _suppliersService.Remove(id);
                if (remove == false)
                {
                    TempData["msg"] = Messages.NoDeleteSupplier;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["msg"] = Messages.AddAction;
                    return RedirectToAction("Index");
                }
            }
        }

        //This Action For Details Supplier
        public IActionResult Details(int id)
        {
            var model = _suppliersService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }
    }
}
