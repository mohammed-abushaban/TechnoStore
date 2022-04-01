using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.ExpensesCategories;
using TechnoStore.Core.ViewModel.ExpensesCategories;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infostructures.Services.ExpensesCategories
{
    public class ExpensesCategoryService : IExpensesCategoryService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        DateTime date = DateTime.Now;
        public static double NumOfPages;

        public ExpensesCategoryService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        //Get All ExpensesCategories To List With or Without Paramrtar
        public List<ExpensesCategoryVm> GetAll(string sreach, int page)
        {
            var NumOfExpCat = _db.ExpensesCategory
                .Count(x => x.Name.Contains(sreach) || string.IsNullOrEmpty(sreach));

            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page20 + 0.0));
            var Skip = (page - 1) * NumPages.page20;
            var Take = NumPages.page20;
            
            var expensesCategory = _db.ExpensesCategory
                .Where(x => x.Name.Contains(sreach) || string.IsNullOrEmpty(sreach))
                .Skip(Skip).Take(Take).ToList();
            return _mapper.Map<List<ExpensesCategoryVm>>(expensesCategory);
        }

        //Get All ExpensesCategories Without Parametar
        public List<ExpensesCategoryVm> GetAll()
        {
            return _mapper.Map<List<ExpensesCategoryVm>>(_db.ExpensesCategory.ToList());
        }

        //Get One ExpensesCategory By Id
        public ExpensesCategoryVm Get(int id)
        {
            return _mapper.Map<ExpensesCategoryVm>(_db.ExpensesCategory.SingleOrDefault(x => x.Id == id));
        }

        //Add A new ExpensesCategory On Database
        public async Task<bool> Save(CreateExpensesCategoryDto dto)
        {
            if (_db.ExpensesCategory.Any(x => x.Name == dto.Name))
            {
                return false;
            }
            else
            {
                var expensesCategory = _mapper.Map<ExpensesCategoryDbEntity>(dto);
                expensesCategory.CreateAt = date;
                expensesCategory.CreateBy = "Test";
                await _db.ExpensesCategory.AddAsync(expensesCategory);
                await _db.SaveChangesAsync();
                return true;
            }
        }

        //Update Specific ExpensesCategory
        public async Task<bool> Update(UpdateExpensesCategoryDto dto)
        {
            if (_db.ExpensesCategory.Any(x => x.Name == dto.Name))
            {
                return false;
            }
            else
            {
                var expensesCategory = _mapper.Map<ExpensesCategoryDbEntity>(dto);
                expensesCategory.UpdateAt = date;
                expensesCategory.UpdateBy = "Test1";
                _db.ExpensesCategory.Update(expensesCategory);
                await _db.SaveChangesAsync();
                return true;
            }

        }

        //Remove ExpensesCategory | Soft Delete | IsDelete = true
        public async Task<bool> Remove(int id)
        {
            var expensesCategory = _db.ExpensesCategory.SingleOrDefault(x => x.Id == id);
            foreach (var item in _db.Expenses.ToList())
            {
                if (expensesCategory.Id == item.ExpensesCategoryId)
                {
                    return false;
                }
            }
            expensesCategory.IsDelete = true;
            _db.ExpensesCategory.Update(expensesCategory);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
