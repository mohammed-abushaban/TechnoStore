using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Suppliers;
using TechnoStore.Core.ViewModel.Suppliers;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infrastructure.Services.Suppliers
{
    public class SuppliersService : ISuppliersService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public static double NumOfPages;

        public SuppliersService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<SupplierVm> GetAll(string search, int page)
        {
            var NumOfExpCat = _db.Suppliers
                .Count(x => x.Name.Contains(search) || string.IsNullOrEmpty(search));

            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page20 + 0.0));
            var Skip = (page - 1) * NumPages.page20;
            var Take = NumPages.page20;

            var suppliers = _db.Suppliers.Where(x => x.Name.Contains(search) || string.IsNullOrEmpty(search))
                .Skip(Skip).Take(Take).ToList();

            return _mapper.Map<List<SupplierVm>>(suppliers);
        }

        public List<SupplierVm> GetAll()
        {
            var suppliers = _db.Suppliers.ToList();
            return _mapper.Map<List<SupplierVm>>(suppliers);
        }

        public SupplierVm Get(int id)
        {
            var supplier = _db.Suppliers.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<SupplierVm>(supplier);
        }
        
        public async Task<bool> Save(string userId, CreateSupplierDto dto)
        {
            var supplier = _mapper.Map<SupplierDbEntity>(dto);
            supplier.CreateAt = DateTime.Now;
            supplier.CreateBy = userId;
            await _db.Suppliers.AddAsync(supplier);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(string userId, UpdateSupplierDto dto)
        {
            var supplier = _db.Suppliers.SingleOrDefault(x => x.Id == dto.Id);
            supplier.UpdateAt = DateTime.Now;
            supplier.UpdateBy = userId;
            _mapper.Map(dto, supplier);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            var supplier = _db.Suppliers.SingleOrDefault(x => x.Id == id);
            supplier.IsDelete = true;
            _db.Suppliers.Update(supplier);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
