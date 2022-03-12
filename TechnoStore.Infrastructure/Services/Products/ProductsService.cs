using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Products;
using TechnoStore.Core.ViewModel.Products;
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
        public List<ProductVm> GetAll()
        {
            var products = _db.Products.Include(x => x.Supplier).Include(x => x.Brand).Include(x => x.SubCategory).ToList();
            return _mapper.Map<List<ProductVm>>(products);
        }

        public ProductVm Get(int id)
        {
            var product = _db.Products.Include(x => x.Supplier).Include(x => x.Brand).Include(x => x.SubCategory).SingleOrDefault(x => x.Id == id);
            return _mapper.Map<ProductVm>(product);
        }

        public List<ProductVm> GetForBrand(int brandId)
        {
            var products = _db.Products.Include(x => x.Supplier).Include(x => x.Brand).Include(x => x.SubCategory).Where(x => x.BrandId == brandId).ToList();
            return _mapper.Map<List<ProductVm>>(products);
        }
        public List<ProductVm> GetForSupplier(int supplierId)
        {
            var products = _db.Products.Include(x => x.Supplier).Include(x => x.Brand).Include(x => x.SubCategory).Where(x => x.SupplierId == supplierId).ToList();
            return _mapper.Map<List<ProductVm>>(products);
        }
        public List<ProductVm> GetForSubCategory(int SubCategoryId)
        {
            var products = _db.Products.Include(x => x.Supplier).Include(x => x.Brand).Include(x => x.SubCategory).Where(x => x.SubCategoryId == SubCategoryId).ToList();
            return _mapper.Map<List<ProductVm>>(products);
        }

        public async Task<bool> Save(string userId, CreateProductDto dto)
        {
            var product = _mapper.Map<ProductDbEntity>(dto);
            product.CreateAt = DateTime.Now;
            product.CreateBy = userId;
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return true;
        }
        
        public async Task<bool> ChangeAvailability(int id, bool status)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == id);
            product.IsAvalable = status;
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return status;
        }

       public async Task<bool> AddDiscount(int id, float dis)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == id);
            product.Discount = dis;
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(string userId, UpdateProductDto dto)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == dto.Id);
            product.UpdateAt = DateTime.Now;
            product.UpdateBy = userId;
            _mapper.Map(dto, product);
            await _db.SaveChangesAsync();
            return true;
        }

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
