using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Cities;
using TechnoStore.Core.ViewModel;
using TechnoStore.Core.ViewModel.Cities;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infrastructure.Services.Cities
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public static double NumOfPages;
        public CityService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public List<CityVm> GetAll(string search, int page)
        {
            var NumOfExpCat = _db.Cities
                .Count(x => x.Name.Contains(search) || string.IsNullOrEmpty(search));

            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page20 + 0.0));
            var Skip = (page - 1) * NumPages.page20;
            var Take = NumPages.page20;

            var cities = _db.Cities
                .Where(x => x.Name.Contains(search) || string.IsNullOrEmpty(search))
                .Skip(Skip).Take(Take).ToList();

            return _mapper.Map<List<CityVm>>(cities);
        }

        public List<CityVm> GetAll()
        {
            return _mapper.Map<List<CityVm>>(_db.Categories.ToList());
        }

        public CityVm Get(int id)
        {
            var city = _db.Cities.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<CityVm>(city);
        }

        public async Task<bool> Save(string userId, CreateCityDto dto)
        {
            if (_db.Cities.Any(x => x.Name == dto.Name))
            {
                return false;
            }
            else
            {
                var city = _mapper.Map<CityDbEntity>(dto);
                city.CreateAt = DateTime.Now;
                city.CreateBy = "Null";
                await _db.Cities.AddAsync(city);
                await _db.SaveChangesAsync();
                return true;
            }

        }

        public async Task<bool> Update(string userId, UpdateCityDto dto)
        {
            var city = _mapper.Map<CityDbEntity>(dto);
            city.UpdateAt = DateTime.Now;
            city.UpdateBy = "Null";
            _db.Cities.Update(city);
            await _db.SaveChangesAsync();
            return true;
        }


        public async Task<bool> Remove(int id)
        {
            var city = _db.Cities.SingleOrDefault(x => x.Id == id);
            foreach (var item in _db.Users.ToList())
            {
                if (city.Id == item.CityId)
                {
                    return false;
                }
            }
            foreach (var item in _db.Warehouses.ToList())
            {
                if (city.Id == item.CityId)
                {
                    return false;
                }

            }
            city.IsDelete = true;
            _db.Cities.Update(city);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}
