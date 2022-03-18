using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Infrastructure.Services.WarehousesProducts;

namespace TechnoStore.Web.Controllers
{
    public class WarehouseProductController : Controller
    {
        private readonly IWarehousesProductsService _warehousesProducts;

        public WarehouseProductController(IWarehousesProductsService warehousesProducts)
        {
            _warehousesProducts = warehousesProducts;
        }

        public async Task<IActionResult> GetProductDetails(int id)
        {
            return Ok(await _warehousesProducts.GetProductDetails(id));
        }

        public async Task<IActionResult> GetWarehouseDetails(int id)
        {
            return Ok(await _warehousesProducts.GetWarehouseDetails(id));
        }
    }
}
