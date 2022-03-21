using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Category;
using TechnoStore.Core.ViewModel.Categories;

namespace TechnoStore.Infrastructure.Services.Categories
{
    public interface ICategoriesService
    {
        List<CategoryVm> GetAll(string sreach, int page);
        List<CategoryVm> GetAll();
        CategoryVm Get(int id);
        Task<bool> Save(string userId, CreateCategoryDto dto, IFormFile image);
        Task<bool> Update(string userId, UpdateCategoryDto dto, IFormFile image);
        Task<bool> Remove(int id);
    }
}
