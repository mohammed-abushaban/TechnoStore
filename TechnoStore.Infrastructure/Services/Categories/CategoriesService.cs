using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //Get All Categories To List With or Without Paramrtar
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

        //Get All Categories Without Parametar
        public List<CategoryVm> GetAll()
        {
            return _mapper.Map<List<CategoryVm>>(_db.Categories.ToList());
        }

        //Get One Category By Id
        public CategoryVm Get(int id)
        {
            return _mapper.Map<CategoryVm>(_db.Categories.SingleOrDefault(x => x.Id == id));
        }

        //Add A new Category On Database
        public async Task<bool> Save(string userId, CreateCategoryDto dto, IFormFile image)
        {
            if (_db.Categories.Any(x => x.Name == dto.Name))
            {
                return false;
            }
            else
            {
                var category = _mapper.Map<CategoryDbEntity>(dto);
                category.CreateAt = DateTime.Now;
                category.CreateBy = "Null";
                var imageUrl = await _fileService.SaveFile(image, "Images/CategoriesImages");
                category.ImageUrl = imageUrl;
                await _db.Categories.AddAsync(category);
                await _db.SaveChangesAsync();
                return true;
            }

        }

        //Update Specific Category
        public async Task<bool> Update(string userId, UpdateCategoryDto dto, IFormFile image)
        {
            if (_db.Categories.Any(x => x.Name == dto.Name))
            {
                return false;
            }
            else
            {
                var category = _mapper.Map<CategoryDbEntity>(dto);
                category.UpdateAt = DateTime.Now;
                category.UpdateBy = "Null";
                if (image != null)
                {
                    if (category.ImageUrl != null)
                    {
                        _fileService.DeleteFile(category.ImageUrl, "Images/CategoriesImages");
                    }
                    var imageUrl = await _fileService.SaveFile(image, "Images/CategoriesImages");
                    category.ImageUrl = imageUrl;
                }
                _db.Categories.Update(category);
                await _db.SaveChangesAsync();
                return true;
            }

        }

        //Remove Category | Soft Delete | IsDelete = true
        public async Task<bool> Remove(int id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == id);
            foreach (var item in _db.SubCategories.ToList())
            {
                if (category.Id == item.CategoryId)
                {
                    return false;
                }
            }
            category.IsDelete = true;
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
