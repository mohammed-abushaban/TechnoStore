using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.ViewModel.WarehousesProducts;

namespace TechnoStore.Infrastructure.Services.WarehousesProducts
{
    public interface IWarehousesProductsService
    {
        Task<WarehouseProductDetailsVm> GetDetails(int id);
    }
}
