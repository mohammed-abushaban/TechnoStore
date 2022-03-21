using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Brands;
using TechnoStore.Core.ViewModel.Brands;

namespace TechnoStore.Infrastructure.Services.Brands
{
    public interface IBrandsService
    {
        List<BrandVm> GetAll(string search, int page);
        List<BrandVm> GetAll();
        BrandVm Get(int id);
        Task<bool> Save(string userId, CreateBrandDto dto, IFormFile image);
        Task<bool> Update(string userId, UpdateBrandDto dto, IFormFile image);
        Task<bool> Remove(int id);
    }
}
