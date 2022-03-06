using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Users;
using TechnoStore.Core.Enums;
using TechnoStore.Infrastructure.Services.Shippers;
using TechnoStore.Infrastructure.Services.Users;

namespace TechnoStore.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IShipperService _shipperService;

        public UserController(IUserService userService, IShipperService shipperService)
        {
            _userService = userService;
            _shipperService = shipperService;
        }
        //This Action For Show All Expenses
        public IActionResult Index(string search, Gender? gender, UserType? userType,int page = 1)
        {
            var model = _userService.GetAll(search, page , gender,userType);

            ViewBag.Search = search;
            ViewBag.gender = gender;
            ViewBag.userYype = userType;
            ViewBag.NumOfPages = UserService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            ViewBag.Category = _userService.GetAll();
            return View(model);
        }
        //This Action For Show page To Add Expenses
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ShipperId"] = new SelectList(_shipperService.GetAll(), "Id", "Name");
            return View();
        }

        //This Action For Add New Expenses
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            dto.CreateBy = "Test";
            dto.CreateAt = DateTime.Now;
            var result = await _userService.Save(dto);
            if (result == false)
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


        //This Action For Soft Delete
        public async Task<IActionResult> Delete(string id)
        {
            var model = _userService.Get(id);
            if (model == null)
            {
                return RedirectToAction("Error", "Settings");
            }
            else
            {
                var result = await _userService.Remove(id);
                if (result == 1)
                {
                    TempData["msg"] = Messages.CanNot2;
                    return RedirectToAction("Index");
                }
                else if (result == 2)
                {
                    TempData["msg"] = Messages.CanNotShip;
                    return RedirectToAction("Index");
                }
                else if (result == 3)
                {
                    TempData["msg"] = Messages.CanNot3;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["msg"] = Messages.DeleteActon;
                    return RedirectToAction("Index");
                }
            }
        }




        //This Action For Details Buy
        public IActionResult Details(string id)
        {
            var model = _userService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }
    }
}
