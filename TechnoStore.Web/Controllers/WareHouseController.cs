using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.WareHouse;
using TechnoStore.Infrastructure.Services.WareHouse;

namespace TechnoStore.Web.Controllers
{
    public class WareHouseController : Controller
    {
        private readonly IWareHouseService _wareHouseService;

        public WareHouseController(IWareHouseService wareHouseService)
        {
            _wareHouseService = wareHouseService;
        }

        public IActionResult GetAll()
        {
            return Ok(_wareHouseService.GetAll());
        }

        public IActionResult GetOne(int id)
        {
            return Ok(_wareHouseService.Get(id));
        }

        public async Task<IActionResult> Create(string userId, [FromForm]CreateWareHouseDto dto)
        {
            return Ok(await _wareHouseService.Save(userId, dto));
        }

        public async Task<IActionResult> Edit(string userId, [FromForm]UpdateWareHouseDto dto)
        {
            return Ok(await _wareHouseService.Update(userId, dto));
        }

        public async Task<IActionResult> Remove(int id)
        {
            return Ok(await _wareHouseService.Remove(id));
        }
    }
}
