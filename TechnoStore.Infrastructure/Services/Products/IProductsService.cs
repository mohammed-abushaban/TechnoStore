using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Products;
using TechnoStore.Core.ViewModel.Products;

namespace TechnoStore.Infrastructure.Services.Products
{
    public interface IProductsService
    {
        List<ProductVm> GetAll(string search, int page);
        List<ProductVm> GetAll();
        ProductVm Get(int id);
        List<ProductVm> GetForBrand(int brandId);
        List<ProductVm> GetForSupplier(int supplierId);
        List<ProductVm> GetForSubCategory(int SubCategoryId);
        Task<bool> Save(string userId, CreateProductDto dto);
        Task<bool> ChangeAvailability(int id, bool status);
        Task<bool> AddDiscount(int id, float dis);
        Task<bool> Update(string userId, UpdateProductDto dto);
        Task<bool> Remove(int id);
    }
}
