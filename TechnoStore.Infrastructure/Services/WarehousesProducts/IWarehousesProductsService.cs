using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.WarehousesProducts;
using TechnoStore.Core.ViewModel.WarehousesProducts;

namespace TechnoStore.Infrastructure.Services.WarehousesProducts
{
    public interface IWarehousesProductsService
    {
        Task<WarehouseProductDetailsVm> GetProductDetails(int id);
        Task<warehouseProductForWarehouseDetailsVm> GetWarehouseDetails(int id);
        Task<List<WarehouseProductVm>> GetAll(string search, int page);
        Task<List<WarehouseProductVm>> GetAll();
        Task<bool> Save(string userId, CreateWarehouseProductDto dto);
        Task<int> GetProductQuantity(int id);

    }
}
