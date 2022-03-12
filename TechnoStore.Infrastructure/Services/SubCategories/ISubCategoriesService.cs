using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.SubCategories;
using TechnoStore.Core.ViewModel.Categories;
using TechnoStore.Core.ViewModel.SubCategories;

namespace TechnoStore.Infrastructure.Services.SubCategories
{
    public interface ISubCategoriesService
    {
        List<SubCategoryVm> GetAll(string search, int page);
        List<SubCategoryVm> GetAll();
        List<CategoryVm> GetAllCategories();
        SubCategoryVm Get(int id);
        Task<bool> Save(string userId, CreateSubCategoryDto dto);
        Task<bool> Update(string userId, UpdateSubCategoryDto dto);
        Task<bool> Remove(int id);

    }
}
