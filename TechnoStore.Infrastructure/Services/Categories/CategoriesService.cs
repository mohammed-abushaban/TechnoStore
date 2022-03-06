using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Category;
using TechnoStore.Core.ViewModel.Categories;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;
using TechnoStore.Infrastructure.Services.Files;

namespace TechnoStore.Infrastructure.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public static double NumOfPages;

        public CategoriesService(ApplicationDbContext db, IMapper mapper, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
        }

        public List<CategoryVm> GetAll(string search, int page)
        {
            var NumOfExpCat = _db.Expenses
                .Count(x => x.Title.Contains(search) || string.IsNullOrEmpty(search));

            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page20 + 0.0));
            var Skip = (page - 1) * NumPages.page20;
            var Take = NumPages.page20;

            var categories = _db.Categories.Include(x => x.SubCategories)
                .Where(x => x.Name.Contains(search) || string.IsNullOrEmpty(search))
                .Skip(Skip).Take(Take).ToList();

            return _mapper.Map<List<CategoryVm>>(categories);
        }

        public List<CategoryVm> GetAll()
        {
            var categories = _db.Categories.ToList();
            return _mapper.Map<List<CategoryVm>>(categories);
        }

        public CategoryVm Get(int id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<CategoryVm>(category);
        }

        public async Task<bool> Save(string userId, CreateCategoryDto dto)
        {
            var category = _mapper.Map<CategoryDbEntity>(dto);
            category.CreateAt = DateTime.Now;
            category.CreateBy = userId;
            var x = await _fileService.SaveFile(dto.Image, "Images/CategoriesImages");
            category.ImageUrl = x;
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(string userId, UpdateCategoryDto dto)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == dto.id);
            category.UpdateAt = DateTime.Now;
            category.UpdateBy = userId;
            if(dto.Image != null)
            {
                await _fileService.DeleteFile(category.ImageUrl);
                var x = await _fileService.SaveFile(dto.Image, "Images/CategoriesImages");
                category.ImageUrl = x;
            }
            _mapper.Map(dto, category);
            await _db.SaveChangesAsync();
            return true;
        }


        public async Task<bool> Remove(int id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == id);
            category.IsDelete = true;
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
