using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Products;
using TechnoStore.Infrastructure.Services.Products;

namespace TechnoStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }


        public IActionResult Index(string search, int page = 1)
        {
            return Ok(_productsService.GetAll(search, page));
        }

        public IActionResult GetAll()
        {
            return Ok(_productsService.GetAll());
        }

        public IActionResult Details(int id)
        {
            return Ok(_productsService.Get(id));
        }

        public async Task<IActionResult> Create(string userId, [FromForm] CreateProductDto dto)
        {
            return Ok(await _productsService.Save(userId, dto));
        }

        public async Task<IActionResult> Update(string userId, [FromForm] UpdateProductDto dto)
        {
            return Ok(await _productsService.Update(userId, dto));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _productsService.Remove(id));
        }

        public IActionResult GetForBrand(int brandId)
        {
            return Ok(_productsService.GetForBrand(brandId));
        }
        public IActionResult GetForSupplier(int supplierId)
        {
            return Ok(_productsService.GetForSupplier(supplierId));
        }
        public IActionResult GetForSubCategory(int supCategoryId)
        {
            return Ok(_productsService.GetForSubCategory(supCategoryId));
        }
        public async Task<IActionResult> ChangeAvailability(int id, bool status)
        {
            return Ok(await _productsService.ChangeAvailability(id, status));
        }
        public async Task<IActionResult> AddDiscount(int id, float dis)
        {
            return Ok(await _productsService.AddDiscount(id, dis));
        }
    }
}
