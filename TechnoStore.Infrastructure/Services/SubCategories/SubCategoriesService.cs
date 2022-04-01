using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.SubCategories;
using TechnoStore.Core.ViewModel.Categories;
using TechnoStore.Core.ViewModel.SubCategories;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infrastructure.Services.SubCategories
{
    public class SubCategoriesService : ISubCategoriesService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public static double NumOfPages;

        public SubCategoriesService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        //Get All SubCategories To List With or Without Paramrtar
        public List<SubCategoryVm> GetAll(string search, int page)
        {
            var num = _db.SubCategories
                .Count(x => x.Name.Contains(search) || string.IsNullOrEmpty(search));
            NumOfPages = Math.Ceiling(num / (NumPages.page20 + 0.0));
            var skip = (page - 1) * NumPages.page20;
            var take = NumPages.page20;

            var subCategories = _db.SubCategories.Include(x => x.Category)
                .Where(x => x.Name.Contains(search) || string.IsNullOrEmpty(search))
                .Skip(skip).Take(take).ToList();

            return _mapper.Map<List<SubCategoryVm>>(subCategories);
        }
        //Get All SubCategories Without Parametar
        public List<SubCategoryVm> GetAll()
        {
            var subCategories = _db.SubCategories.Include(x => x.Category).ToList();
            return _mapper.Map<List<SubCategoryVm>>(subCategories);
        }

        //Get All Categories To List Without Parametar
        public List<CategoryVm> GetAllCategories()
        {
            return _mapper.Map<List<CategoryVm>>(_db.Categories.ToList());
        }

        //Get One SubCategory By Id
        public SubCategoryVm Get(int id)
        {
            return _mapper.Map<SubCategoryVm>(_db.SubCategories.Include(x => x.Category).SingleOrDefault(x => x.Id == id));
        }

        //Add A new SubCategory On Database
        public async Task<bool> Save(string userId, CreateSubCategoryDto dto)
        {
            if (_db.SubCategories.Any(x => x.Name == dto.Name))
            {
                return false;
            }
            else
            {
                var subCategory = _mapper.Map<SubCategoryDbEntity>(dto);
                subCategory.CreateAt = DateTime.Now;
                subCategory.CreateBy = "Test";
                await _db.SubCategories.AddAsync(subCategory);
                await _db.SaveChangesAsync();
                return true;
            }
        }

        //Update Specific SubCategory
        public async Task<bool> Update(string userId, UpdateSubCategoryDto dto)
        {
            if (_db.SubCategories.Any(x => x.Name == dto.Name))
            {
                return false;
            }
            else
            {
                var subCategory = _db.SubCategories.SingleOrDefault(x => x.Id == dto.Id);
                subCategory.UpdateAt = DateTime.Now;
                subCategory.UpdateBy = "Test";
                _mapper.Map(dto, subCategory);
                await _db.SaveChangesAsync();
                return true;
            }

        }

        //Remove SubCategory | Soft Delete | IsDelete = true
        public async Task<bool> Remove(int id)
        {
            var subCategory = _db.SubCategories.SingleOrDefault(x => x.Id == id);
            foreach (var item in _db.Products.ToList())
            {
                if (subCategory.Id == item.SubCategoryId)
                {
                    return false;
                }
            }
            subCategory.IsDelete = true;
            _db.SubCategories.Update(subCategory);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
