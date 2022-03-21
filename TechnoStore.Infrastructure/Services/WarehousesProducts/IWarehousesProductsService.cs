using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.WarehousesProducts;
using TechnoStore.Core.ViewModel.Products;
using TechnoStore.Core.ViewModel.WareHouses;
using TechnoStore.Core.ViewModel.WarehousesProducts;

namespace TechnoStore.Infrastructure.Services.WarehousesProducts
{
    public interface IWarehousesProductsService
    {
        List<WarehouseProductVm> GetAll(string search, int page);
        List<WarehouseProductVm> GetAll();
        List<ProductVm> GetAllProducts();
        List<WareHouseVm> GetAllWarehoues();
        WarehouseProductVm Get(int id);
        int GetProductQuantity(int id);
        int GetProductOnOneWarehouseQuantity(int id);
        Task<bool> Save(string userId, CreateWarehouseProductDto dto, IFormFile image);
        Task<bool> Update(string userId, UpdateWarehouseProductDto dto, IFormFile image);
        Task<bool> Remove(int id);
        WarehouseProductDetailsVm GetProductDetails(int id);
        warehouseProductForWarehouseDetailsVm GetWarehouseDetails(int id);



    }
}
