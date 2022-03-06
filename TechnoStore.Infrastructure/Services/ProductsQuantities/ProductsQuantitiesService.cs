using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.ProductsQuantities;
using TechnoStore.Core.ViewModel.ProductsQuantities;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infrastructure.Services.ProductsQuantities
{
    public class ProductsQuantitiesService : IProductsQuantitiesService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public static double NumOfPages;

        public ProductsQuantitiesService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public List<ProductQuantityVm> GetProductQuantity(int productId, int page, string colorSearch)
        {
            var num = _db.ProductQuantities
                .Count(x => x.Color.Contains(colorSearch) || string.IsNullOrEmpty(colorSearch));

            NumOfPages = Math.Ceiling(num / (NumPages.page20 + 0.0));
            var skip = (page - 1) * NumPages.page20;
            var take = NumPages.page20;

            var quantities = _db.ProductQuantities.Include(x => x.Product).Where(x => x.Color.Contains(colorSearch) || string.IsNullOrEmpty(colorSearch))
                .Skip(skip).Take(take).ToList();

            return _mapper.Map<List<ProductQuantityVm>>(quantities);
        }

        public List<ProductQuantityVm> GetAll()
        {
            var quantities = _db.ProductQuantities.Include(x => x.Product).ToList();
            return _mapper.Map<List<ProductQuantityVm>>(quantities);
        }

        public ProductQuantityVm Get(int id)
        {
            var quantities = _db.ProductQuantities.Include(x => x.Product).SingleOrDefault(x => x.Id == id);
            return _mapper.Map<ProductQuantityVm>(quantities);
        }

        public async Task<bool> Save(string userId, CreateProductQuantityDto dto)
        {
            var quantity = _mapper.Map<ProductQuantityDbEntity>(dto);
            quantity.CreateAt = DateTime.Now;
            quantity.CreateBy = userId;
            await _db.ProductQuantities.AddAsync(quantity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(string userId, UpdateProductQuantityDto dto)
        {
            var quantity = _db.ProductQuantities.SingleOrDefault(x => x.Id == dto.Id);
            quantity.UpdateAt = DateTime.Now;
            quantity.UpdateBy = userId;
            _mapper.Map(dto, quantity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            var quantity = _db.ProductQuantities.SingleOrDefault(x => x.Id == id);
            quantity.IsDelete = true;
            _db.ProductQuantities.Update(quantity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
