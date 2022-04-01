using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Sms;
using TechnoStore.Infrastructure.Services.Sms;
using Microsoft.AspNetCore.Authorization;

namespace TechnoStore.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SmsController : BaseController
    {
        private readonly ISmsService _smsService;
        public SmsController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        //This Action For Show All Sms
        public IActionResult Index(string search, int page = 1)
        {
            var model = _smsService.GetAll(search, page);

            ViewBag.Search = search;
            ViewBag.NumOfPages = SmsService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            return View(model);
        }

    }
}
