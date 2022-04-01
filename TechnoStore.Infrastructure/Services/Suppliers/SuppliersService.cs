using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //Get All Suppliers To List With or Without Paramrtar
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

        //Get All Suppliers Without Parametar
        public List<SupplierVm> GetAll()
        {
            return _mapper.Map<List<SupplierVm>>(_db.Suppliers.ToList());
        }

        //Get One Supplier By Id
        public SupplierVm Get(int id)
        {
            return _mapper.Map<SupplierVm>(_db.Suppliers.SingleOrDefault(x => x.Id == id));
        }

        //Add A new Supplier On Database
        public async Task<bool> Save(string userId, CreateSupplierDto dto)
        {
            if (_db.Suppliers.Any(x => x.Name == dto.Name))
            {
                return false;
            }
            else
            {
                var supplier = _mapper.Map<SupplierDbEntity>(dto);
                supplier.CreateAt = DateTime.Now;
                supplier.CreateBy = "Test";
                await _db.Suppliers.AddAsync(supplier);
                await _db.SaveChangesAsync();
                return true;
            }
        }

        //Update Specific Supplier
        public async Task<bool> Update(string userId, UpdateSupplierDto dto)
        {
            if (_db.Suppliers.Any(x => x.Name == dto.Name))
            {
                return false;
            }
            else
            {
                var supplier = _db.Suppliers.SingleOrDefault(x => x.Id == dto.Id);
                supplier.UpdateAt = DateTime.Now;
                supplier.UpdateBy = "Test";
                _mapper.Map(dto, supplier);
                await _db.SaveChangesAsync();
                return true;
            }

        }

        //Remove Supplier | Soft Delete | IsDelete = true
        public async Task<bool> Remove(int id)
        {
            var supplier = _db.Suppliers.SingleOrDefault(x => x.Id == id);
            foreach (var item in _db.Products.ToList())
            {
                if (supplier.Id == item.SupplierId)
                {
                    return false;
                }
            }
            supplier.IsDelete = true;
            _db.Suppliers.Update(supplier);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
