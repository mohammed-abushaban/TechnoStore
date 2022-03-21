using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Expenses;
using TechnoStore.Core.ViewModel.Expenses;
using TechnoStore.Core.ViewModel.ExpensesCategories;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infrastructure.Services.Expenses
{
    public class ExpensesService : IExpensesService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        DateTime date = DateTime.Now;
        public static double NumOfPages;

        public ExpensesService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        //Get All Expenses To List With or Without Paramrtar
        public List<ExpensesVm> GetAll(string sreach, int page)
        {
            var NumOfExpCat = _db.Expenses
                .Count(x => x.Title.Contains(sreach) || string.IsNullOrEmpty(sreach));

            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page20 + 0.0));
            var Skip = (page - 1) * NumPages.page20;
            var Take = NumPages.page20;

            var expensess = _db.Expenses.Include(x => x.ExpensesCategory)
                .Where(x => x.Title.Contains(sreach) || string.IsNullOrEmpty(sreach))
                .Skip(Skip).Take(Take).ToList();
            return _mapper.Map<List<ExpensesVm>>(expensess);
        }

        //Get All Expenses Without Parametar
        public List<ExpensesVm> GetAll()
        {
            return _mapper.Map<List<ExpensesVm>>(_db.Expenses.ToList());
        }

        //Get All ExpensesCategoey Without Parametar
        public List<ExpensesCategoryVm> GetAllExpensesCategories()
        {
            return _mapper.Map<List<ExpensesCategoryVm>>(_db.ExpensesCategory.ToList());
        }

        //Get One Expenses By Id
        public ExpensesVm Get(int id)
        {
            return _mapper.Map<ExpensesVm>(_db.Expenses.SingleOrDefault(x => x.Id == id));
        }

        //Add A new Expenses On Database
        public async Task<bool> Save(CreateExpensesDto dto)
        {
            var expenses = _mapper.Map<ExpensesDbEntity>(dto);
            expenses.CreateAt = date;
            expenses.CreateBy = "Test";
            await _db.Expenses.AddAsync(expenses);
            await _db.SaveChangesAsync();
            return true;
        }

        //Update Specific Expenses
        public async Task<int> Update(UpdateExpensesDto dto)
        {
            var expenses = _mapper.Map<ExpensesDbEntity>(dto);
            expenses.UpdateAt = date;
            expenses.UpdateBy = "Test1";
            _db.Expenses.Update(expenses);
            await _db.SaveChangesAsync();
            return expenses.Id;
        }

        //Remove Expenses | Soft Delete | IsDelete = true
        public async Task Remove(int id)
        {
            var expenses = _db.Expenses.SingleOrDefault(x => x.Id == id);
            expenses.IsDelete = true;
            _db.Expenses.Update(expenses);
            await _db.SaveChangesAsync();
        }
    }
}
