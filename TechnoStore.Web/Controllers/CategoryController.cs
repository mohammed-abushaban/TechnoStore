using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Category;
using TechnoStore.Infrastructure.Services.Categories;

namespace TechnoStore.Web.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoriesService _categoriesService;

        public CategoryController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public IActionResult Index(string search, int page = 1)
        {
            return Ok(_categoriesService.GetAll(search, page));
        }

        public IActionResult GetAll()
        {
            return Ok(_categoriesService.GetAll());
        }

        public IActionResult Details(int id)
        {
            return Ok(_categoriesService.Get(id));
        }

        public async Task<IActionResult> Create(string userId, [FromForm] CreateCategoryDto dto)
        {
            return Ok(await _categoriesService.Save(userId, dto));
        }

        public async Task<IActionResult> Update(string userId, [FromForm] UpdateCategoryDto dto)
        {
            return Ok(await _categoriesService.Update(userId, dto));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _categoriesService.Remove(id));
        }
    }
}
