using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Category;
using TechnoStore.Infrastructure.Services.Categories;
using TechnoStore.Infrastructure.Services.Products;

namespace TechnoStore.Web.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoriesService _categoriesService;


        public CategoryController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        //This Action For Show All Categories
        public IActionResult Index(string search, int page = 1)
        {
            var model = _categoriesService.GetAll(search, page);

            ViewBag.Search = search;
            ViewBag.NumOfPages = CategoriesService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            return View(model);
        }
        //This Action For Show page To Add Category
        [HttpGet]
        public IActionResult Create() => View();

        //This Action For Add New Category
        [HttpPost]
        public async Task<IActionResult> Create(string userId, CreateCategoryDto dto, IFormFile image)
        {
            if(dto.About == null)
            {
                dto.About = "Null";
            }    
            var result = await _categoriesService.Save(userId,dto, image);
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

        //This Action For Show page To Edit Category
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _categoriesService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");

            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            ViewBag.ImageUrl = model.ImageUrl;
            return View(model);
        }
        //This Action For Edit Category
        [HttpPost]
        public async Task<IActionResult> Edit(string userId,UpdateCategoryDto dto, IFormFile image)
        {
            if (dto.About == null)
            {
                dto.About = "Null";
            }
            bool result = await _categoriesService.Update(userId,dto, image);
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
            var model = _categoriesService.Get(id);
            if (model == null)
            {
                return RedirectToAction("Error", "Settings");
            }
            else
            {
                var result = await _categoriesService.Remove(id);
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
        //This Action For Details Category
        public IActionResult Details(int id)
        {
            var model = _categoriesService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }
    }
}
