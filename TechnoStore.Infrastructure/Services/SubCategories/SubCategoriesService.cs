using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.SubCategories;
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

        public List<SubCategoryVm> GetAll()
        {
            var subCategories = _db.SubCategories.Include(x => x.Category).ToList();
            return _mapper.Map<List<SubCategoryVm>>(subCategories);
        }

        public SubCategoryVm Get(int id)
        {
            var subCategory = _db.SubCategories.Include(x => x.Category).SingleOrDefault(x => x.Id == id);
            return _mapper.Map<SubCategoryVm>(subCategory);
        }

        public async Task<bool> Save(string userId, CreateSubCategoryDto dto)
        {
            var subCategory = _mapper.Map<SubCategoryDbEntity>(dto);
            subCategory.CreateAt = DateTime.Now;
            subCategory.CreateBy = userId;
            await _db.SubCategories.AddAsync(subCategory);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(string userId, UpdateSubCategoryDto dto)
        {
            var subCategory = _db.SubCategories.SingleOrDefault(x => x.Id == dto.Id);
            subCategory.UpdateAt = DateTime.Now;
            subCategory.UpdateBy = userId;
            _mapper.Map(dto, subCategory);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            var subCategory = _db.SubCategories.SingleOrDefault(x => x.Id == id);
            subCategory.IsDelete = true;
            _db.SubCategories.Update(subCategory);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
