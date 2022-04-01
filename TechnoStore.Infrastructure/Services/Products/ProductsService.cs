using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Products;
using TechnoStore.Core.ViewModel.Brands;
using TechnoStore.Core.ViewModel.Products;
using TechnoStore.Core.ViewModel.SubCategories;
using TechnoStore.Core.ViewModel.Suppliers;
using TechnoStore.Core.ViewModel.WareHouses;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;
using TechnoStore.Infrastructure.Services.Files;
using TechnoStore.Infrastructure.Services.WarehousesProducts;

namespace TechnoStore.Infrastructure.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public static double NumOfPages;
        private readonly IWarehousesProductsService _warehousesProductsService;
        private readonly IFileService _fileService;


        public ProductsService(ApplicationDbContext db, IMapper mapper
            , IWarehousesProductsService warehousesProductsService , IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _warehousesProductsService = warehousesProductsService;
            _fileService = fileService;
        }
        //Get All Products To List With or Without Paramrtar
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
        //Get All Products Without Parametar
        public List<ProductVm> GetAll()
        {
            var products = _db.Products.Include(x => x.Supplier)
                .Include(x => x.Brand).Include(x => x.SubCategory).ToList();
            return _mapper.Map<List<ProductVm>>(products);
        }
        //Get One Product By Id
        public ProductVm Get(int id)
        {
            var product = _db.Products.Include(x => x.Supplier)
                .Include(x => x.Brand).Include(x => x.SubCategory).SingleOrDefault(x => x.Id == id);
            return _mapper.Map<ProductVm>(product);
        }


        //Get All Products With One Brand 
        public List<ProductVm> GetForBrand(int brandId)
        {
            var products = _db.Products.Include(x => x.Supplier)
                .Include(x => x.Brand).Include(x => x.SubCategory).Where(x => x.BrandId == brandId).ToList();
            return _mapper.Map<List<ProductVm>>(products);
        }
        //Get All Products With One Suppliers 
        public List<ProductVm> GetForSupplier(int supplierId)
        {
            var products = _db.Products.Include(x => x.Supplier)
                .Include(x => x.Brand).Include(x => x.SubCategory).Where(x => x.SupplierId == supplierId).ToList();
            return _mapper.Map<List<ProductVm>>(products);
        }
        //Get All Products With One SubCategoty 
        public List<ProductVm> GetForSubCategory(int SubCategoryId)
        {
            var products = _db.Products.Include(x => x.Supplier)
                .Include(x => x.Brand).Include(x => x.SubCategory).Where(x => x.SubCategoryId == SubCategoryId).ToList();
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
        //Get All Warehouse
        public List<WareHouseVm> GetAllWarehouses()
        {
            return _mapper.Map<List<WareHouseVm>>(_db.Warehouses.ToList());
        }
        //Add A new Product On Database
        public async Task<bool> Save(string userId, CreateProductDto dto, IFormFile image)
        {
            //var product = _mapper.Map<ProductDbEntity>(dto);

            var product = new ProductDbEntity();
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.PriceBuy = dto.PriceBuy;
            product.PriceSale = dto.PriceSale;
            product.Code = dto.Code;
            product.Discount = dto.Discount;
            product.BrandId = dto.BrandId;
            product.SubCategoryId = dto.SubCategoryId;
            product.SupplierId = dto.SupplierId;
            product.CreateAt = DateTime.Now;
            product.CreateBy = "Test";
            _db.Products.Add(product);
            _db.SaveChanges();

            var listProduct = _db.Products.SingleOrDefault
                (x => x.Name == product.Name && x.Code == product.Code);
            var warehouseProduct = new WarehouseProductDbEntity();
            warehouseProduct.ProductId = listProduct.Id;
            warehouseProduct.WarehouseId = dto.WarehouseId;
            warehouseProduct.Color = dto.Color;
            warehouseProduct.Size = dto.Size;
            warehouseProduct.Quantity = dto.Quantity;
            var imageUrl = await _fileService.SaveFile(image, "Images/WarehouseProducts");
            warehouseProduct.ImageUrl = imageUrl;

            _db.warehouseProducts.Add(warehouseProduct);
            _db.SaveChanges();
            return true;
        }


        //Update Specific Product
        public async Task<bool> Update(string userId, UpdateProductDto dto)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == dto.Id);
            product.UpdateAt = DateTime.Now;
            product.UpdateBy = "Test";
            _mapper.Map(dto, product);
            await _db.SaveChangesAsync();
            return true;
        }

        //Remove Product | Soft Delete | IsDelete = true
        public async Task<bool> Remove(int id)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == id);
            product.IsDelete = true;
            _db.Products.Update(product);
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
    }
}
