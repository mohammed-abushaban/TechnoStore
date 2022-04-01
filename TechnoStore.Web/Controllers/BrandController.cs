using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Brands;
using TechnoStore.Infrastructure.Services.Brands;
using TechnoStore.Infrastructure.Services.Products;

namespace TechnoStore.Web.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IBrandsService _brandsService;
        private readonly IProductsService _productsService;

        public BrandController(IBrandsService brandsService, IProductsService productsService)
        {
            _brandsService = brandsService;
            _productsService = productsService;
        }

        //This Action For Show All Brands
        public IActionResult Index(string search, int page = 1)
        {
            var model = _brandsService.GetAll(search, page);

            ViewBag.Search = search;
            ViewBag.NumOfPages = BrandsService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            return View(model);
        }

        //This Action For Show page To Add Brand
        [HttpGet]
        public IActionResult Create() => View();

        //This Action For Add New Category
        [HttpPost]
        public async Task<IActionResult> Create(string userId, CreateBrandDto dto, IFormFile image)
        {
            if (dto.About == null)
            {
                dto.About = "Null";
            }
            var result = await _brandsService.Save(userId, dto, image);
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

        //This Action For Show page To Edit Brand
        [HttpGet]
        public IActionResult Edit(int id)
        {  
            var model = _brandsService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            //جلب وقت الانشاء والمستخدم الذي انشاءه
            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }
        
        //This Action For Edit Brand
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, UpdateBrandDto dto, IFormFile image)
        {
            if (dto.About == null)
            {
                dto.About = "Null";
            }
            var result = await _brandsService.Update(userId, dto, image);
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
            var model = _brandsService.Get(id);
            if (model == null)
            {
                return RedirectToAction("Error", "Settings");
            }
            else
            {
                var result = await _brandsService.Remove(id);
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
        //This Action For Details Brand
        public IActionResult Details(int id)
        {
            var model = _brandsService.Get(id);
            if (model == null)
            {
                return RedirectToAction("Error", "Settings");
            }
            else
            {
                var products = _productsService.GetForBrand(id);
                ViewBag.products = products;
                return View(model);
            }
        }
    }
}
