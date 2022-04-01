using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Products;
using TechnoStore.Core.ViewModel.Brands;
using TechnoStore.Core.ViewModel.Products;
using TechnoStore.Core.ViewModel.SubCategories;
using TechnoStore.Core.ViewModel.Suppliers;
using TechnoStore.Core.ViewModel.WareHouses;

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
        List<BrandVm> GetAllBrands();
        List<SupplierVm> GetAllSuppliers();
        List<SubCategoryVm> GetAllSubCategories();
        List<WareHouseVm> GetAllWarehouses();
        Task<bool> Save(string userId, CreateProductDto dto, IFormFile image);
        Task<bool> ChangeAvailability(int id, bool status);
        Task<bool> AddDiscount(int id, float dis);
        Task<bool> Update(string userId, UpdateProductDto dto);
        Task<bool> Remove(int id);
    }
}
