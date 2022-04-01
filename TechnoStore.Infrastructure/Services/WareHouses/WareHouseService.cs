using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.WareHouse;
using TechnoStore.Core.ViewModel.Cities;
using TechnoStore.Core.ViewModel.Users;
using TechnoStore.Core.ViewModel.WareHouses;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infrastructure.Services.WareHouse
{
    public class WareHouseService : IWareHouseService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public static double NumOfPages;

        public WareHouseService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        //Get All Warehouses To List With or Without Paramrtar
        public List<WareHouseVm> GetAll(string search, int page)
        {
            var num = _db.Warehouses
                .Count(x => x.Name.Contains(search) || string.IsNullOrEmpty(search));
            NumOfPages = Math.Ceiling(num / (NumPages.page20 + 0.0));
            var skip = (page - 1) * NumPages.page20;
            var take = NumPages.page20;

            var wareHouses = _db.Warehouses.Include(y => y.City).Include(y => y.User)
                .Where(x => x.Name.Contains(search) || string.IsNullOrEmpty(search))
                .Skip(skip).Take(take).ToList();

            return _mapper.Map<List<WareHouseVm>>(wareHouses);
        }

        //Get All Warehouses Without Parametar
        public List<WareHouseVm> GetAll()
        {
            return _mapper.Map<List<WareHouseVm>>(_db.Warehouses.ToList());
        }

        //Get All Cities Without Parametar
        public List<CityVm> GetAllCities()
        {
            return _mapper.Map<List<CityVm>>(_db.Cities.ToList());
        }
        //Get All Users Without Parametar
        public List<UserVm> GetAllUsers()
        {
            return _mapper.Map<List<UserVm>>(_db.Users
                .Where(x => x.UserType == Core.Enums.UserType.Admin 
                || x.UserType == Core.Enums.UserType.User).ToList());
        }
        //Get One Warehouse By Id
        public WareHouseVm Get(int id)
        {
            return _mapper.Map<WareHouseVm>(_db.Warehouses.Include(y => y.City).Include(y => y.User).SingleOrDefault(x => x.Id == id));
        }

        //Add A new Warehouse On Database
        public async Task<bool> Save(CreateWareHouseDto dto)
        {
            if (_db.Warehouses.Any(x => x.Name == dto.Name))
            {
                return false;
            }
            else
            {
                var warehouse = _mapper.Map<WarehouseDbEntity>(dto);
                warehouse.CreateBy = "Test";
                warehouse.CreateAt = DateTime.Now;
                await _db.Warehouses.AddAsync(warehouse);
                await _db.SaveChangesAsync();
                return true;
            }

        }

        //Update Specific Warehouse
        public async Task<bool> Update(UpdateWareHouseDto dto)
        {
            if (_db.Warehouses.Any(x => x.Name == dto.Name))
            {
                return false;
            }
            else
            {
                var warehouse = _db.Warehouses.SingleOrDefault(x => x.Id == dto.Id);
                warehouse.UpdateAt = DateTime.Now;
                warehouse.UpdateBy = "Test";
                _mapper.Map(dto, warehouse);
                await _db.SaveChangesAsync();
                return true;
            }

        }

        //Remove Warehouse | Soft Delete | IsDelete = true
        public async Task<bool> Remove(int id)
        {
            var warehouse = _db.Warehouses.SingleOrDefault(x => x.Id == id);
            warehouse.IsDelete = true;
            _db.Warehouses.Update(warehouse);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
