using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Products;
using TechnoStore.Core.ViewModel.Brands;
using TechnoStore.Core.ViewModel.Products;
using TechnoStore.Core.ViewModel.SubCategories;
using TechnoStore.Core.ViewModel.Suppliers;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infrastructure.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public static double NumOfPages;

        public ProductsService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        //GEt All Products
        public List<ProductVm> GetAll(string search, int page)
        {
            var num = _db.Products
                .Count(x => x.Name.Contains(search) || string.IsNullOrEmpty(search));
            NumOfPages = Math.Ceiling(num / (NumPages.page20 + 0.0));
            var skip = (page - 1) * NumPages.page20;
            var take = NumPages.page20;

            var products = _db.Products.Include(x => x.Supplier).Include(x => x.Brand).Include(x => x.SubCategory)
                .Where(x => x.Name.Contains(search) || string.IsNullOrEmpty(search))
                .Skip(skip).Take(take).ToList();
            
            return _mapper.Map<List<ProductVm>>(products);
        }
        //Get All Products Without Parameter
        public List<ProductVm> GetAll()
        {
            var products = _db.Products.Include(x => x.Supplier).Include(x => x.Brand).Include(x => x.SubCategory).ToList();
            return _mapper.Map<List<ProductVm>>(products);
        }
        //Get One Product
        public ProductVm Get(int id)
        {
            var product = _db.Products.Include(x => x.Supplier).Include(x => x.Brand).Include(x => x.SubCategory).SingleOrDefault(x => x.Id == id);
            return _mapper.Map<ProductVm>(product);
        }

        //Get All Products With One Brand 
        public List<ProductVm> GetForBrand(int? brandId)
        {
            var products = _db.Products.Include(x => x.Supplier).Include(x => x.Brand).Include(x => x.SubCategory).Where(x => x.BrandId == brandId).ToList();
            return _mapper.Map<List<ProductVm>>(products);
        }
        //Get All Products With One Suppliers 
        public List<ProductVm> GetForSupplier(int? supplierId)
        {
            var products = _db.Products.Include(x => x.Supplier).Include(x => x.Brand).Include(x => x.SubCategory).Where(x => x.SupplierId == supplierId).ToList();
            return _mapper.Map<List<ProductVm>>(products);
        }
        //Get All Products With One SubCategoty 
        public List<ProductVm> GetForSubCategory(int? SubCategoryId)
        {
            var products = _db.Products.Include(x => x.Supplier).Include(x => x.Brand).Include(x => x.SubCategory).Where(x => x.SubCategoryId == SubCategoryId).ToList();
            return _mapper.Map<List<ProductVm>>(products);
        }

        //Get All Brands
        public List<BrandVm> GetAllBrands()
        {
            return _mapper.Map<List<BrandVm>>(_db.Brands.ToList());
        }
        //Get All Suppliers
        public List<SupplierVm> GetAllSuppliers()
        {
            return _mapper.Map<List<SupplierVm>>(_db.Suppliers.ToList());
        }
        //Get All SubCategories
        public List<SubCategoryVm> GetAllSubCategories()
        {
            return _mapper.Map<List<SubCategoryVm>>(_db.SubCategories.ToList());
        }

        //Create A New Product
        public async Task<bool> Save(string userId, CreateProductDto dto)
        {
            var product = _mapper.Map<ProductDbEntity>(dto);
            product.CreateAt = DateTime.Now;
            product.CreateBy = "Test";
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return true;
        }

        //Change A Availability For Any Product
        public async Task<bool> ChangeAvailability(int id, bool status)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == id);
            product.IsAvalable = status;
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return status;
        }
        //Change A Discount For Any Product
       public async Task<bool> AddDiscount(int id, float dis)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == id);
            product.Discount = dis;
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return true;
        }

        //Update A New Product
        public async Task<bool> Update(string userId, UpdateProductDto dto)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == dto.Id);
            product.UpdateAt = DateTime.Now;
            product.UpdateBy = "Test";
            _mapper.Map(dto, product);
            await _db.SaveChangesAsync();
            return true;
        }

        //Delete Any Expenses
        public async Task<bool> Remove(int id)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == id);
            product.IsDelete = true;
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
