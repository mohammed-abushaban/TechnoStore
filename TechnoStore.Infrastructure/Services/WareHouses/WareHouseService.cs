using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.WareHouse;
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

        // Get all WareHouses by searching or page number
        public List<WareHouseVm> GetAll(string search, int page)
        {
            var num = _db.Warehouses
                .Count(x => x.Name.Contains(search) || string.IsNullOrEmpty(search));
            NumOfPages = Math.Ceiling(num / (NumPages.page20 + 0.0));
            var skip = (page - 1) * NumPages.page20;
            var take = NumPages.page20;

            var wareHouses = _db.Warehouses.Where(x => x.Name.Contains(search) || string.IsNullOrEmpty(search))
                .Skip(skip).Take(take).ToList();

            return _mapper.Map<List<WareHouseVm>>(wareHouses);
        }

        // Get all wareHouses in the system
        public List<WareHouseVm> GetAll()
        {
            var warehouses = _db.Warehouses.ToList();
            return _mapper.Map<List<WareHouseVm>>(warehouses);
        }

        //get one wareHouses

        public WareHouseVm Get(int id)
        {
            var warehouse = _db.Warehouses.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<WareHouseVm>(warehouse);
        }

        // Create a new WareHouse
        public async Task<bool> Save(string userId, CreateWareHouseDto dto)
        {
            var warehouse = _mapper.Map<WarehouseDbEntity>(dto);
            warehouse.CreateBy = userId;
            warehouse.CreateAt = DateTime.Now;
            await _db.Warehouses.AddAsync(warehouse);
            await _db.SaveChangesAsync();
            return true;
        }

        // Update wareHouse informations
        public async Task<bool> Update(string userId, UpdateWareHouseDto dto)
        {
            var warehouse = _db.Warehouses.SingleOrDefault(x => x.Id == dto.Id);
            warehouse.UpdateAt = DateTime.Now;
            warehouse.UpdateBy = userId;
            _mapper.Map(dto, warehouse);
            await _db.SaveChangesAsync();
            return true;
        }

        // Delete a wareHouse
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
