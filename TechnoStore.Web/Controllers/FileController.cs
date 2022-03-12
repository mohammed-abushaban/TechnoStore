using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Files;
using TechnoStore.Infrastructure.Services.Files;

namespace TechnoStore.Web.Controllers
{
    public class FileController : BaseController
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        //This Action For Show All File
        public IActionResult Index(string search, int page = 1)
        {
            var model = _fileService.GetAll(search, page);

            ViewBag.Search = search;
            ViewBag.NumOfPages = FileService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            return View(model);
        }

        //This Action For Show page To Add File
        [HttpGet]
        public IActionResult Create() => View();

        //This Action For Add New File
        [HttpPost]
        public async Task<IActionResult> Create(CreateFileDto dto)
        {
            var id = await _fileService.Save(dto);
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

        //This Action For Show page To Edit File
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _fileService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            //جلب وقت الانشاء والمستخدم الذي انشاءه
            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }

        //This Action For Edit File
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateFileDto dto)
        {
            await _fileService.Update(dto);
            TempData["msg"] = Messages.EditAction;
            return RedirectToAction("Index");
        }

        //This Action For Soft Delete
        public async Task<IActionResult> Delete(int id)
        {
            var model = _fileService.Get(id);
            if (model == null)
            {
                return RedirectToAction("Error", "Settings");
            }
            else
            {
                var remove = await _fileService.Remove(id);
                if (remove == 0)
                {
                    TempData["msg"] = Messages.NoDeleteCategory;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["msg"] = Messages.AddAction;
                    return RedirectToAction("Index");
                }
            }
        }

        //This Action For Details Buy
        public IActionResult Details(int id)
        {
            var model = _fileService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }
    }
}
