﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Brands;
using TechnoStore.Core.ViewModel.Brands;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;
using TechnoStore.Infrastructure.Services.Files;

namespace TechnoStore.Infrastructure.Services.Brands
{
    public class BrandsService : IBrandsService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public static double NumOfPages;

        public BrandsService(ApplicationDbContext db, IMapper mapper, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
        }

        public List<BrandVm> GetAll(string search, int page)
        {
            var NumOfExpCat = _db.Expenses
                .Count(x => x.Title.Contains(search) || string.IsNullOrEmpty(search));

            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page20 + 0.0));
            var Skip = (page - 1) * NumPages.page20;
            var Take = NumPages.page20;

            var brands = _db.Brands.Include(x => x.Products)
                .Where(x => x.Name.Contains(search) || string.IsNullOrEmpty(search))
                .Skip(Skip).Take(Take).ToList();

            return _mapper.Map<List<BrandVm>>(brands);
        }

        public List<BrandVm> GetAll()
        {
            var brands = _db.Brands.ToList();
            return _mapper.Map<List<BrandVm>>(brands);
        }

        public BrandVm Get(int id)
        {
            var brand = _db.Brands.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<BrandVm>(brand);
        }

        public async Task<bool> Save(string userId, CreateBrandDto dto, IFormFile image)
        {
            if (_db.Brands.Any(x => x.Name == dto.Name))
            {
                return false;
            }
            else
            {
                var brand = _mapper.Map<BrandDbEntity>(dto);
                brand.CreateBy = "Test";
                brand.CreateAt = DateTime.Now;
                var x = await _fileService.SaveFile(image, "Images/BrandsImages");
                brand.ImageUrl = x;
                await _db.Brands.AddAsync(brand);
                await _db.SaveChangesAsync();
                return true;
            }

        }

        public async Task<bool> Update(string userId, UpdateBrandDto dto, IFormFile image)
        {
            var brand = _db.Brands.SingleOrDefault(x => x.Id == dto.Id);
            brand.UpdateAt = DateTime.Now;
            brand.UpdateBy = "Test";
            if (image != null)
            {
                _fileService.DeleteFile(brand.ImageUrl, "Images/BrandsImages");
                var x = await _fileService.SaveFile(image, "Images/BrandsImages");
                brand.ImageUrl = x;
            }
            _mapper.Map(dto, brand);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            var brand = _db.Brands.SingleOrDefault(x => x.Id == id);
            foreach (var item in _db.Products.ToList())
            {
                if (brand.Id == item.BrandId)
                {
                    return false;
                }
            }
            brand.IsDelete = true;
            _db.Brands.Update(brand);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
