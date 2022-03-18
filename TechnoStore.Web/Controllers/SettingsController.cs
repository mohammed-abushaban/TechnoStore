using Microsoft.AspNetCore.Http;
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
    public class SettingsController : BaseController
    {
        private readonly ISettingService _settingService;

        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        //This Action For Show All Setting
        public IActionResult Index()
        {
            if(_settingService.GetSetting() == null)
            {
                return RedirectToAction("Edit", "Settings");
            }
            return View(_settingService.GetSetting());
        }


        //This Action For Show page To Edit Setting
        [HttpGet]
        public IActionResult Edit()
        {
            var model = _settingService.GetSetting();
            if(model == null)
            {
                ViewBag.CreateAt = DateTime.Now;
                ViewBag.CreateBy = "Admin";
                return View(model);
            }
            else
            {
                ViewBag.CreateAt = model.CreateAt;
                ViewBag.CreateBy = model.CreateBy;
                return View(model);
            }
        }

        //This Action For Edit Setting
        [HttpPost]
        public async Task<IActionResult> Edit(CreateSettingDto dto , IFormFile logo)
        {
            
            if(_settingService.GetSetting() == null)
            {
                await _settingService.Save(dto, logo);
                TempData["msg"] = Messages.AddAction;
            }
            else
            {
                await _settingService.Update(dto, logo);
                TempData["msg"] = Messages.EditAction;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
