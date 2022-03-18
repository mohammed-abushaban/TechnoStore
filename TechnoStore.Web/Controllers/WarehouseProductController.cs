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

        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _warehousesProducts.GetDetails(id));
        }
    }
}
