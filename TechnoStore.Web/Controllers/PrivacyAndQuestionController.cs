using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.PrivacyAndQuestions;
using TechnoStore.Infrastructure.Services.PrivacyAndQuestions;
using TechnoStore.Infrastructure.Services.Sms;

namespace TechnoStore.Web.Controllers
{
    public class PrivacyAndQuestionController : BaseController
    {
        private readonly IPrivacyAndQuestionService _privacyAndQuestionService;
        public PrivacyAndQuestionController(IPrivacyAndQuestionService privacyAndQuestionService)
        {
            _privacyAndQuestionService = privacyAndQuestionService;
        }

        //This Action For Show All PrivacyAndQuestion
        public IActionResult Index()
        {
            var model = _privacyAndQuestionService.GetAll();
            return View(model);
        }

        //This Action For Show page To Add PrivacyAndQuestion
        [HttpGet]
        public IActionResult Create() => View();

        //This Action For Add New PrivacyAndQuestion
        [HttpPost]
        public async Task<IActionResult> Create(CreatePrivacyAndQuestionDto dto)
        {
            await _privacyAndQuestionService.Save(dto);
            TempData["msg"] = Messages.AddAction;
            return RedirectToAction("Index");
        }

        //This Action For Show page To Edit PrivacyAndQuestion
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _privacyAndQuestionService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            //جلب وقت الانشاء والمستخدم الذي انشاءه
            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }

        //This Action For Edit PrivacyAndQuestion
        [HttpPost]
        public async Task<IActionResult> Edit(UpdatePrivacyAndQuestionDto dto)
        {
            await _privacyAndQuestionService.Update(dto);
            TempData["msg"] = Messages.EditAction;
            return RedirectToAction("Index");
        }

        //This Action For Soft Delete
        public async Task<IActionResult> Delete(int id)
        {
            var model = _privacyAndQuestionService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            await _privacyAndQuestionService.Remove(id);
            TempData["msg"] = Messages.DeleteActon;
            return RedirectToAction("Index");
        }

        //This Action For Details Buy
        public IActionResult Details(int id)
        {
            var model = _privacyAndQuestionService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }
    }
}
