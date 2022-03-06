using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Brands;
using TechnoStore.Infrastructure.Services.Brands;

namespace TechnoStore.Web.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IBrandsService _brandsService;

        public BrandController(IBrandsService brandsService)
        {
            _brandsService = brandsService;
        }

        public IActionResult Index(string search, int page = 1)
        {
            return Ok(_brandsService.GetAll(search, page));
        }

        public IActionResult GetAll()
        {
            return Ok(_brandsService.GetAll());
        }

        public IActionResult Details(int id)
        {
            return Ok(_brandsService.Get(id));
        }

        public async Task<IActionResult> Create(string userId, [FromForm] CreateBrandDto dto)
        {
            return Ok(await _brandsService.Save(userId, dto));
        }

        public async Task<IActionResult> Update(string userId, [FromForm] UpdateBrandDto dto)
        {
            return Ok(await _brandsService.Update(userId, dto));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _brandsService.Remove(id));
        }
    }
}
