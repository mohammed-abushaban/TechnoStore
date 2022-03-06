using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Suppliers;
using TechnoStore.Infrastructure.Services.Suppliers;

namespace TechnoStore.Web.Controllers
{
    public class SupplierController : BaseController
    {
        private readonly ISuppliersService _suppliersService;

        public SupplierController(ISuppliersService suppliersService)
        {
            _suppliersService = suppliersService;
        }
        public IActionResult Index(string search, int page = 1)
        {
            return Ok(_suppliersService.GetAll(search, page));
        }

        public IActionResult GetAll()
        {
            return Ok(_suppliersService.GetAll());
        }

        public IActionResult Details(int id)
        {
            return Ok(_suppliersService.Get(id));
        }

        public async Task<IActionResult> Create(string userId, [FromForm] CreateSupplierDto dto)
        {
            return Ok(await _suppliersService.Save(userId, dto));
        }

        public async Task<IActionResult> Update(string userId, [FromForm] UpdateSupplierDto dto)
        {
            return Ok(await _suppliersService.Update(userId, dto));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _suppliersService.Remove(id));
        }
    }
}
