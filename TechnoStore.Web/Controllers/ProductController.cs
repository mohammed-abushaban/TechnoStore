using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Products;
using TechnoStore.Infrastructure.Services.Products;

namespace TechnoStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        //This Action For Show All Expenses
        public IActionResult Index(string search,
            int? SupplierId, int? BrandId,
            int? SubCategoryId, int page = 1)
        {
            //if(SupplierId != null)
            //{
            //    var getProductsWithSupplier = _productsService.GetForSupplier(SupplierId);
            //}
            //else if(BrandId != null)
            //{
            //    var getProductsWithBrand = _productsService.GetForBrand(BrandId);
            //}
            //else if(SubCategoryId != null)
            //{
            //    var getProductsWithSubCategory = _productsService.GetForSubCategory(SubCategoryId);
            //}


            var model = _productsService.GetAll(search, page);
            ViewBag.Search = search;
            ViewBag.NumOfPages = ProductsService.NumOfPages;
            ViewBag.Page = page;
            ViewBag.count = model.Count();
            ViewBag.PriceBuy = model.ToList().Sum(x => x.PriceBuy);
            ViewBag.PriceSale = model.ToList().Sum(x => x.PriceSale);

            ViewData["BrandId"] = new SelectList(_productsService.GetAllBrands(), "Id", "Name");
            ViewData["SubCategoryId"] = new SelectList(_productsService.GetAllSubCategories(), "Id", "Name");
            ViewData["SupplierId"] = new SelectList(_productsService.GetAllSuppliers(), "Id", "Name");
            return View(model);
        }
        //This Action For Show page To Add Expenses
        [HttpGet]
        public IActionResult Create()
        {
            //إضافة تحقق قبل فتح الصفحة
            if (_productsService.GetAllBrands().Count() <= 0 || 
                _productsService.GetAllSubCategories().Count() <= 0 || 
                _productsService.GetAllSuppliers().Count() <= 0)
            {
                TempData["msg"] = Messages.NoCategory;
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["BrandId"] = new SelectList(_productsService.GetAllBrands(), "Id", "Name");
                ViewData["SubCategoryId"] = new SelectList(_productsService.GetAllSubCategories(), "Id", "Name");
                ViewData["SupplierId"] = new SelectList(_productsService.GetAllSuppliers(), "Id", "Name");
                //Create Code
                Random random = new Random();
                var HashCode = random.Next(1000, 9999);
                if (_productsService.GetAll().Any(x => x.Code == HashCode + ""))
                {
                    var HashCode2 = random.Next(1000, 9999);
                    ViewBag.HashCode = HashCode2;
                }
                ViewBag.HashCode = HashCode;
                return View();
            }
        }

        //This Action For Add New Expenses
        [HttpPost]
        public async Task<IActionResult> Create(string userId, CreateProductDto dto)
        {

            await _productsService.Save(userId,dto);
            TempData["msg"] = Messages.AddAction;
            return RedirectToAction("Index");
        }

        //This Action For Show page To Edit Expenses
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _productsService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");

            ViewData["BrandId"] = new SelectList(_productsService.GetAllBrands(), "Id", "Name");
            ViewData["SubCategoryId"] = new SelectList(_productsService.GetAllSubCategories(), "Id", "Name");
            ViewData["SupplierId"] = new SelectList(_productsService.GetAllSuppliers(), "Id", "Name");
            //جلب وقت الانشاء والمستخدم الذي انشاءه
            ViewBag.CreateAt = model.CreateAt;
            ViewBag.CreateBy = model.CreateBy;
            return View(model);
        }

        //This Action For Edit Expenses
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, UpdateProductDto dto)
        {
            await _productsService.Update(userId,dto);
            TempData["msg"] = Messages.EditAction;
            return RedirectToAction("Index");
        }

        //This Action For Soft Delete
        public async Task<IActionResult> Delete(int id)
        {
            var model = _productsService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            await _productsService.Remove(id);
            TempData["msg"] = Messages.DeleteActon;
            return RedirectToAction("Index");
        }

        //This Action For Details Buy
        public IActionResult Details(int id)
        {
            var model = _productsService.Get(id);
            if (model == null)
                return RedirectToAction("Error", "Settings");
            return View(model);
        }



        public IActionResult GetForBrand(int brandId)
        {
            return View(_productsService.GetForBrand(brandId));
        }
        public IActionResult GetForSupplier(int supplierId)
        {
            return View(_productsService.GetForSupplier(supplierId));
        }
        public IActionResult GetForSubCategory(int supCategoryId)
        {
            return View(_productsService.GetForSubCategory(supCategoryId));
        }
        public async Task<IActionResult> ChangeAvailability(int id, bool status)
        {
            return View(await _productsService.ChangeAvailability(id, status));
        }

        public async Task<IActionResult> AddDiscount(int id, float dis)
        {
            return View(await _productsService.AddDiscount(id, dis));
        }
    }
}
