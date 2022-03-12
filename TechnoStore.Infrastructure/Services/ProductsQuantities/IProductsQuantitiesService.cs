using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.ProductsQuantities;
using TechnoStore.Core.ViewModel.Products;
using TechnoStore.Core.ViewModel.ProductsQuantities;

namespace TechnoStore.Infrastructure.Services.ProductsQuantities
{
    public interface IProductsQuantitiesService
    {
        List<ProductQuantityVm> GetAll(string search, int page);
        List<ProductQuantityVm> GetAll();
        List<ProductVm> GetAllProducts();
        ProductQuantityVm Get(int id);
        Task<bool> Save(string userId, CreateProductQuantityDto dto);
        Task<bool> Update(string userId, UpdateProductQuantityDto dto);
        Task<bool> Remove(int id);
    }
}
