using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Shippers;
using TechnoStore.Core.ViewModel.Shippers;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infrastructure.Services.Shippers
{
    public class ShipperService : IShipperService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        DateTime date = DateTime.Now;
        public static double NumOfPages;

        public ShipperService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        //Get All Shipper
        public List<ShipperVm> GetAll(string sreach, int page)
        {
            var NumOfExpCat = _db.ShipperDbEntity
                .Count(x => x.Name.Contains(sreach) || string.IsNullOrEmpty(sreach));

            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page20 + 0.0));
            var Skip = (page - 1) * NumPages.page20;
            var Take = NumPages.page20;
            var shippers = _db.ShipperDbEntity
                .Where(x => x.Name.Contains(sreach) || string.IsNullOrEmpty(sreach))
                .Skip(Skip).Take(Take).ToList();

            return _mapper.Map<List<ShipperVm>>(shippers);
        }

        //Get All To List
        public List<ShipperVm> GetAll()
        {
            var shipper = _db.ShipperDbEntity.ToList();
            return _mapper.Map<List<ShipperVm>>(shipper);
        }

        //Get One Shipper
        public ShipperVm Get(int id)
        {
            var shippers = _db.ShipperDbEntity.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<ShipperVm>(shippers);
        }

        //Create A New Shipper
        public async Task<bool> Save(CreateShipperDto dto)
        {
            if (_db.ShipperDbEntity.Any(x => x.Name == dto.Name))
            {
                return false;
            }
            var shipper = _mapper.Map<ShipperDbEntity>(dto);
            shipper.CreateAt = date;
            shipper.CreateBy = "Test";
            await _db.ShipperDbEntity.AddAsync(shipper);
            await _db.SaveChangesAsync();
            return true;
        }

        //Update Any Shipper
        public async Task<int> Update(UpdateShipperDto dto)
        {
            var shipper = _mapper.Map<ShipperDbEntity>(dto);
            shipper.UpdateAt = date;
            shipper.UpdateBy = "Test1";
            _db.ShipperDbEntity.Update(shipper);
            await _db.SaveChangesAsync();
            return shipper.Id;
        }

        //Delete Any Shipper
        public async Task<bool> Remove(int id)
        {
            var shipper = _db.ShipperDbEntity.SingleOrDefault(x => x.Id == id);

            //foreach (var item in _db.ShipperDbEntity.ToList())
            //{
            //    if (shipper.Id == item.ExpensesCategoryId)
            //    {
            //        return 0;
            //    }
            //}
            shipper.IsDelete = true;
            _db.ShipperDbEntity.Update(shipper);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
