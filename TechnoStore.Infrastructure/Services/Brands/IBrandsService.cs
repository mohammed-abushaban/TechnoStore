using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        Task<bool> Save(string userId, CreateBrandDto dto);
        Task<bool> Update(string userId, UpdateBrandDto dto);
        Task<bool> Remove(int id);
    }
}
