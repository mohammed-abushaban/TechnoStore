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

        //Get All Expenses
        public List<ExpensesCategoryVm> GetAll(string sreach, int page)
        {
            var NumOfExpCat = _db.ExpensesCategory
                .Count(x => x.Name.Contains(sreach) || string.IsNullOrEmpty(sreach));

            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page20 + 0.0));
            var Skip = (page - 1) * NumPages.page20;
            var Take = NumPages.page20;
            var expensess = _db.ExpensesCategory
                .Where(x => x.Name.Contains(sreach) || string.IsNullOrEmpty(sreach))
                .Skip(Skip).Take(Take).ToList();

            return _mapper.Map<List<ExpensesCategoryVm>>(expensess);
        }
        
        //Get All To List
        public List<ExpensesCategoryVm> GetAll()
        {
            var expensess = _db.ExpensesCategory.ToList();
            return _mapper.Map<List<ExpensesCategoryVm>>(expensess);
        }

        //Get One Expenses
        public ExpensesCategoryVm Get(int id)
        {
            var expenses = _db.ExpensesCategory.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<ExpensesCategoryVm>(expenses);
        }

        //Create A New Expenses
        public async Task<int> Save(CreateExpensesCategoryDto dto)
        {
            if (_db.ExpensesCategory.Any(x => x.Name == dto.Name))
            {
                return 0;
            }
            var expenses = _mapper.Map<ExpensesCategoryDbEntity>(dto);
            expenses.CreateAt = date;
            await _db.ExpensesCategory.AddAsync(expenses);
            await _db.SaveChangesAsync();
            return expenses.Id;
        }

        //Update A New Expenses
        public async Task<int> Update(UpdateExpensesCategoryDto dto)
        {
            var expenses = _mapper.Map<ExpensesCategoryDbEntity>(dto);
            expenses.UpdateAt = date;
            _db.ExpensesCategory.Update(expenses);
            await _db.SaveChangesAsync();
            return expenses.Id;
        }

        //Delete Any Expenses
        public async Task<int> Remove(int id)
        {
            var expenses = _db.ExpensesCategory.SingleOrDefault(x => x.Id == id);
            foreach (var item in _db.Expenses.ToList())
            {
                if (expenses.Id == item.ExpensesCategoryId)
                {
                    return 0;
                }
            }
            expenses.IsDelete = true;
            _db.ExpensesCategory.Update(expenses);
            await _db.SaveChangesAsync();
            return expenses.Id;
        }
    }
}
