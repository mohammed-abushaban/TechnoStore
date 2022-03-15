using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Feedbacks;
using TechnoStore.Infostructures.Services.IFeedbacks;

namespace TechnoStore.Web.Controllers
{
    public class FeedbackController : BaseController
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        //This Action For Show All Feedbacks
        public IActionResult Index(string search, int page = 1)
        {
            var model = _feedbackService.GetAll(search, page);

            ViewBag.Search = search;
            ViewBag.NumOfPages = FeedbackService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            return View(model);
        }

        //This Action For Show page To Add Feedback
        [HttpGet]
        public IActionResult Create() => View();

        //This Action For Add New Feedback
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeedbackDto dto)
        {
            await _feedbackService.Save(dto);
            TempData["msg"] = Messages.AddAction;
            return RedirectToAction("Index");
        }

        //This Action For Soft Delete
        public async Task<IActionResult> Delete(int id)
        {
            var model = _feedbackService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            await _feedbackService.Remove(id);
            TempData["msg"] = Messages.DeleteActon;
            return RedirectToAction("Index");
        }

        //This Action For Details Buy
        public IActionResult Details(int id)
        {
            var model = _feedbackService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }
    }
}
