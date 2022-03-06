using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.SubCategories;
using TechnoStore.Infrastructure.Services.SubCategories;

namespace TechnoStore.Web.Controllers
{
    public class SubCategoryController : BaseController
    {
        private readonly ISubCategoriesService _subCategoriesService;

        public SubCategoryController(ISubCategoriesService subCategoriesService)
        {
            _subCategoriesService = subCategoriesService;
        }

        public IActionResult Index(string search, int page = 1)
        {
            return Ok(_subCategoriesService.GetAll(search, page));
        }

        public IActionResult GetAll()
        {
            return Ok(_subCategoriesService.GetAll());
        }

        public IActionResult Details(int id)
        {
            return Ok(_subCategoriesService.Get(id));
        }

        public async Task<IActionResult> Create(string userId, [FromForm] CreateSubCategoryDto dto)
        {
            return Ok(await _subCategoriesService.Save(userId, dto));
        }
        
        public async Task<IActionResult> Update(string userId, [FromForm] UpdateSubCategoryDto dto)
        {
            return Ok(await _subCategoriesService.Update(userId, dto));
        }

        public async Task<IActionResult> Remove(int id)
        {
            return Ok(await _subCategoriesService.Remove(id));
        }

    }
}
