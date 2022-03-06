using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        Task<bool> Save(string userId, CreateCategoryDto dto);
        Task<bool> Update(string userId, UpdateCategoryDto dto);
        Task<bool> Remove(int id);
    }
}
