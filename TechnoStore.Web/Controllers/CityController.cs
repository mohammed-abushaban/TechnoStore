using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Cities;
using TechnoStore.Infrastructure.Services.Cities;

namespace TechnoStore.Web.Controllers
{
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        //This Action For Show All Cities
        public IActionResult Index(string search, int page = 1)
        {
            var model = _cityService.GetAll(search, page);

            ViewBag.Search = search;
            ViewBag.NumOfPages = CityService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            return View(model);
        }
        //This Action For Show page To Add City
        [HttpGet]
        public IActionResult Create() => View();

        //This Action For Add New City
        [HttpPost]
        public async Task<IActionResult> Create(string userId, CreateCityDto dto)
        {

            var result = await _cityService.Save(userId, dto);
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

        //This Action For Show page To Edit City
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _cityService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");

            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }
        //This Action For Edit City
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, UpdateCityDto dto)
        {

            bool result = await _cityService.Update(userId, dto);
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
            var model = _cityService.Get(id);
            if (model == null)
            {
                return RedirectToAction("Error", "Settings");
            }
            else
            {
                var result = await _cityService.Remove(id);
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
        //This Action For Details City
        public IActionResult Details(int id)
        {
            var model = _cityService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }
    }
}
