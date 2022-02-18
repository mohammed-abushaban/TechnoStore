using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.ExpensesCategories;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infostructures.Services.ExpensesCategories
{
    public class ExpensesCategoryService : IExpensesCategoryService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        DateTime date = DateTime.Now;
        public static double NumOfPages;

        public ExpensesCategoryService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        //Get All Expenses
        public List<ExpensesCategoryDto> GetAll(string sreach, int page)
        {
            var NumOfExpCat = db.ExpensesCategory.Count(x => x.Name.Contains(sreach) || string.IsNullOrEmpty(sreach));

            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page20 + 0.0));
            var Skip = (page - 1) * NumPages.page20;
            var Take = NumPages.page20;
            var expensess = db.ExpensesCategory.Where(x => x.Name.Contains(sreach) || string.IsNullOrEmpty(sreach)).Skip(Skip).Take(Take).ToList();

            return mapper.Map<List<ExpensesCategoryDto>>(expensess);
        }
        
        //Get All To List
        public List<ExpensesCategoryDto> GetList()
        {
            var expensess = db.ExpensesCategory.ToList();
            return mapper.Map<List<ExpensesCategoryDto>>(expensess);
        }

        //Get One Expenses
        public ExpensesCategoryDto Get(int id)
        {
            var expenses = db.ExpensesCategory.SingleOrDefault(x => x.Id == id);
            return mapper.Map<ExpensesCategoryDto>(expenses);
        }

        //Create A New Expenses
        public async Task<int> Save(CreateExpensesCategoryDto dto)
        {
            var expenses = mapper.Map<ExpensesCategoryDbEntity>(dto);
            expenses.CreateAt = date;
            await db.ExpensesCategory.AddAsync(expenses);
            await db.SaveChangesAsync();
            return expenses.Id;
        }

        //Update A New Expenses
        public async Task<int> Update(UpdateExpensesCategoryDto dto)
        {
            var expenses = mapper.Map<ExpensesCategoryDbEntity>(dto);
            expenses.UpdateAt = date;
            db.ExpensesCategory.Update(expenses);
            await db.SaveChangesAsync();
            return expenses.Id;
        }

        //Delete Any Expenses
        public async Task Remove(int id)
        {
            var expenses = db.ExpensesCategory.SingleOrDefault(x => x.Id == id);
            expenses.IsDelete = true;
            db.ExpensesCategory.Update(expenses);
            await db.SaveChangesAsync();
        }
    }
}
