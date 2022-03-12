using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Infrastructure.Services;

namespace TechnoStore.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async  Task<IActionResult> InitRole()
        {
            var result = await _roleService.InitRole();
            return Ok(result);
        }
    }
}
