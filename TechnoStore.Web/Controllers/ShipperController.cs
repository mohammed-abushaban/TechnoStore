using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Shippers;
using TechnoStore.Infrastructure.Services.Shippers;

namespace TechnoStore.Web.Controllers
{
    public class ShipperController : BaseController
    {
        private readonly IShipperService _shipperService;
        public ShipperController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        //This Action For Show All Shippers
        public IActionResult Index(string search, int page = 1)
        {
            var model = _shipperService.GetAll(search, page);

            ViewBag.Search = search;
            ViewBag.NumOfPages = ShipperService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            return View(model);
        }

        //This Action For Show page To Add Shipper
        [HttpGet]
        public IActionResult Create() => View();

        //This Action For Add New Shipper
        [HttpPost]
        public async Task<IActionResult> Create(CreateShipperDto dto, IFormFile image)
        {
            var result = await _shipperService.Save(dto , image);
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

        //This Action For Show page To Edit Shipper
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _shipperService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");

            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            ViewBag.ImageUrl = model.ImageUrl;
            return View(model);
        }

        //This Action For Edit Shipper
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateShipperDto dto, IFormFile image)
        {
            await _shipperService.Update(dto, image);
            TempData["msg"] = Messages.EditAction;
            return RedirectToAction("Index");
        }

        //This Action For Soft Delete
        public async Task<IActionResult> Delete(int id)
        {
            var model = _shipperService.Get(id);
            if (model == null)
            {
                return RedirectToAction("Error", "Settings");
            }
            else
            {
                var remove = await _shipperService.Remove(id);
                if (remove == false)
                {
                    TempData["msg"] = Messages.NoDeleteShipper;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["msg"] = Messages.AddAction;
                    return RedirectToAction("Index");
                }
            }
        }

        //This Action For Details Shipper
        public IActionResult Details(int id)
        {
            var model = _shipperService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }
    }
}
