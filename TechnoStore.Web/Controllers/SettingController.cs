using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Settings;
using TechnoStore.Infrastructure.Services.Settings;

namespace TechnoStore.Web.Controllers
{
    public class SettingController : BaseController
    {
        private readonly ISettingService _settingService;
        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        //This Action For Show All Setting
        public IActionResult Index()
        {
            var model = _settingService.GetAll();
            return View(model);
        }

        //This Action For Show page To Add Setting
        [HttpGet]
        public IActionResult Create() => View();

        //This Action For Add New Setting
        [HttpPost]
        public async Task<IActionResult> Create(CreateSettingDto dto)
        {
            var id = await _settingService.Save(dto);
            if (id == 0)
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

        //This Action For Show page To Edit Setting
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _settingService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            //جلب وقت الانشاء والمستخدم الذي انشاءه
            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }

        //This Action For Edit Setting
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateSettingDto dto)
        {
            await _settingService.Update(dto);
            TempData["msg"] = Messages.EditAction;
            return RedirectToAction("Index");
        }

        

        
    }
}
