using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.ProductsQuantities;
using TechnoStore.Core.ViewModel.ProductsQuantities;

namespace TechnoStore.Infrastructure.Services.ProductsQuantities
{
    public interface IProductsQuantitiesService
    {
        List<ProductQuantityVm> GetProductQuantity(int productId, int page, string colorSearch);
        List<ProductQuantityVm> GetAll();
        ProductQuantityVm Get(int id);
        Task<bool> Save(string userId, CreateProductQuantityDto dto);
        Task<bool> Update(string userId, UpdateProductQuantityDto dto);
        Task<bool> Remove(int id);
    }
}
