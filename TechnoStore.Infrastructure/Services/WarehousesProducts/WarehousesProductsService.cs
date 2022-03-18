using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.WarehousesProducts;
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

        //Get all warehousesProducts

        public async Task<List<WarehouseProductVm>> GetAll(string search, int page)
        {
            var num = _db.warehouseProducts.Count();
            NumOfPages = Math.Ceiling(num / (NumPages.page20 + 0.0));
            var skip = (page - 1) * NumPages.page20;
            var take = NumPages.page20;

            var warehouseProducts = _db.warehouseProducts.Include(x => x.Warehouse).Include(x => x.Product)
                .Skip(skip).Take(take).ToList();

            return _mapper.Map<List<WarehouseProductVm>>(warehouseProducts);
        }

        public async Task<List<WarehouseProductVm>> GetAll()
        {
            var warehouseProducts = _db.warehouseProducts.Include(x => x.Warehouse).Include(x => x.Product).ToList();
            return _mapper.Map<List<WarehouseProductVm>>(warehouseProducts);
        }

        //Add a new warehouseProduct
        public async Task<bool> Save(string userId, CreateWarehouseProductDto dto)
        {
            var warehouseProduct = _mapper.Map<WarehouseProductDbEntity>(dto);
            warehouseProduct.CreateAt = DateTime.Now;
            warehouseProduct.CreateBy = "Test";
            var x = await _fileService.SaveFile(dto.ImageUrl, "Images/WarehouseProducts");
            warehouseProduct.ImageUrl = x;
            await _db.warehouseProducts.AddAsync(warehouseProduct);
            await _db.SaveChangesAsync();
            return true;
        }

        //Get Product Details
        public async Task<WarehouseProductDetailsVm> GetProductDetails(int id)
        {
            var warehouseProduct = _db.warehouseProducts.Include(x => x.Warehouse).Include(x => x.Product)
                .Where(x => x.ProductId == id).ToList();

            var l = warehouseProduct.FirstOrDefault();
            var result = _mapper.Map<WarehouseProductDetailsVm>(l);
            result.TotalQuantity = 0;
            foreach (var item in warehouseProduct)
            {
                result.TotalQuantity += item.Quantity;
            }
            result.wareHousesVm = new List<wareHouseForProductDetailsVm>();
            for(int i = 0; i < warehouseProduct.Count(); i++)
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
        public async Task<warehouseProductForWarehouseDetailsVm> GetWarehouseDetails(int id)
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
        // update

        // remove


    }
}