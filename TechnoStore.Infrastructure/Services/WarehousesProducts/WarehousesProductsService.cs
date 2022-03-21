using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.WarehousesProducts;
using TechnoStore.Core.ViewModel.Products;
using TechnoStore.Core.ViewModel.WareHouses;
using TechnoStore.Core.ViewModel.WarehousesProducts;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;
using TechnoStore.Infrastructure.Services.Files;

namespace TechnoStore.Infrastructure.Services.WarehousesProducts
{
    public class WarehousesProductsService : IWarehousesProductsService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public static double NumOfPages;
        private readonly IFileService _fileService;

        public WarehousesProductsService(ApplicationDbContext db, IMapper mapper, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
        }

        //Get All WarehouseProducts To List With or Without Paramrtar
        public List<WarehouseProductVm> GetAll(string search, int page)
        {
            var num = _db.warehouseProducts.Include(x => x.Product).Include(y => y.Warehouse)
                .Count(x => x.Product.Name.Contains(search) || x.Warehouse.Name.Contains(search) || string.IsNullOrEmpty(search));
            NumOfPages = Math.Ceiling(num / (NumPages.page20 + 0.0));
            var skip = (page - 1) * NumPages.page20;
            var take = NumPages.page20;

            var warehouseProducts = _db.warehouseProducts.Include(x => x.Warehouse).Include(x => x.Product)
                .Where(x => x.Product.Name.Contains(search) || x.Warehouse.Name.Contains(search) || string.IsNullOrEmpty(search))
                .Skip(skip).Take(take).ToList();

            return _mapper.Map<List<WarehouseProductVm>>(warehouseProducts);
        }

        //Get All WarehouseProduct Without Parametar
        public List<WarehouseProductVm> GetAll()
        {
            var warehouseProducts = _db.warehouseProducts.Include(x => x.Warehouse).Include(x => x.Product).ToList();
            return _mapper.Map<List<WarehouseProductVm>>(warehouseProducts);
        }

        //Get All Product Without Parametar
        public List<ProductVm> GetAllProducts()
        {
            return _mapper.Map<List<ProductVm>>(_db.Products.ToList());
        }

        //Get All WareHouse Without Parametar
        public List<WareHouseVm> GetAllWarehoues()
        {
            return _mapper.Map<List<WareHouseVm>>(_db.Warehouses.ToList());
        }

        //Get One WarehouseProduct By Id
        public WarehouseProductVm Get(int id)
        {
            var warehouse = _db.warehouseProducts.Include(x => x.Warehouse).Include(x => x.Product).SingleOrDefault(x => x.Id == id);
            return _mapper.Map<WarehouseProductVm>(warehouse);
        }

        //Add A new WarehouseProduct On Database
        public async Task<bool> Save(string userId, CreateWarehouseProductDto dto, IFormFile image)
        {
            var warehouseProduct = _mapper.Map<WarehouseProductDbEntity>(dto);
            warehouseProduct.CreateAt = DateTime.Now;
            warehouseProduct.CreateBy = "Test";
            var x = await _fileService.SaveFile(image, "Images/WarehouseProducts");
            warehouseProduct.ImageUrl = x;
            await _db.warehouseProducts.AddAsync(warehouseProduct);
            await _db.SaveChangesAsync();
            return true;
        }
        //Update Specific WarehouseProduct
        public async Task<bool> Update(string userId, UpdateWarehouseProductDto dto, IFormFile image)
        {
            var warehouseProduct = _db.warehouseProducts.SingleOrDefault(x => x.Id == dto.Id);
            warehouseProduct.UpdateAt = DateTime.Now;
            warehouseProduct.UpdateBy = "Test";
            if (image != null)
            {
                if (warehouseProduct.ImageUrl != null)
                {
                    _fileService.DeleteFile(warehouseProduct.ImageUrl, "Images/WarehouseProducts");
                }
                var x = await _fileService.SaveFile(image, "Images/WarehouseProducts");
                warehouseProduct.ImageUrl = x;
            }
            _mapper.Map(dto, warehouseProduct);
            await _db.SaveChangesAsync();
            return true;
        }

        //Remove WarehouseProduct | Soft Delete | IsDelete = true
        public async Task<bool> Remove(int id)
        {
            var warehouseProduct = _db.warehouseProducts.SingleOrDefault(x => x.Id == id);
            warehouseProduct.IsDelete = true;
            _db.warehouseProducts.Update(warehouseProduct);
            await _db.SaveChangesAsync();
            return true;
        }

        //Get Product Details for All warehouses
        public WarehouseProductDetailsVm GetProductDetails(int id)
        {
            var warehouseProduct = _db.warehouseProducts.Include(x => x.Warehouse).Include(x => x.Product)
                .Where(x => x.ProductId == id).ToList();

            var nameproductAndWarehouse = warehouseProduct.FirstOrDefault();
            var result = _mapper.Map<WarehouseProductDetailsVm>(nameproductAndWarehouse);
            result.TotalQuantity = warehouseProduct.Sum(x => x.Quantity);
            result.wareHousesVm = new List<wareHouseForProductDetailsVm>();
            for (int i = 0; i < warehouseProduct.Count(); i++)
            {
                var m = new wareHouseForProductDetailsVm
                {
                    WarehouseName = warehouseProduct[i].Warehouse.Name,
                    Color = warehouseProduct[i].Color,
                    Size = warehouseProduct[i].Size,
                    Quantity = warehouseProduct[i].Quantity
                };
                result.wareHousesVm.Add(m);
            }
            return result;
        }

        // get details for one warehouse
        public warehouseProductForWarehouseDetailsVm GetWarehouseDetails(int id)
        {
            var warehouseProduct = _db.warehouseProducts.Include(x => x.Warehouse).ThenInclude(x => x.City).Include(x => x.Product)
                .Where(x => x.WarehouseId == id).ToList();
            var l = warehouseProduct.FirstOrDefault();
            var result = _mapper.Map<warehouseProductForWarehouseDetailsVm>(l);
            result.productDetails = new List<ProductDetailsForWarehouseDetailsVm>();
            result.City = l.Warehouse.City.Name;
            for (int i = 0; i < warehouseProduct.Count(); i++)
            {
                var m = new ProductDetailsForWarehouseDetailsVm
                {
                    Name = warehouseProduct[i].Product.Name,
                    Color = warehouseProduct[i].Color,
                    Size = warehouseProduct[i].Size,
                    Quantity = warehouseProduct[i].Quantity,
                    Id = warehouseProduct[i].ProductId,
                    ImageUrl = warehouseProduct[i].ImageUrl
                };
                result.productDetails.Add(m);
            }
            return result;
        }

        //return TotalQuantity for Specific Product
        public int GetProductQuantity(int id)
        {
            return _db.warehouseProducts.Where(x => x.ProductId == id).ToList().Sum(x => x.Quantity);
        }

        //return TotalQuantity for Specific Warehouse
        public int GetProductOnOneWarehouseQuantity(int id)
        {
            return _db.warehouseProducts.Where(x => x.WarehouseId == id).Count();
        }
    }
}