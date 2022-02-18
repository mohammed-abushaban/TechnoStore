using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Expenses;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infrastructure.Services.Expenses
{
    public class ExpensesService : IExpensesService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        DateTime date = DateTime.Now;
        public static double NumOfPages;

        public ExpensesService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        //Get All Expenses
        public List<ExpensesDto> GetAll(string sreach, int page)
        {
            var NumOfExpCat = db.Expenses.Count(x => x.Title.Contains(sreach) || string.IsNullOrEmpty(sreach));

            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page20 + 0.0));
            var Skip = (page - 1) * NumPages.page20;
            var Take = NumPages.page20;
            var expensess = db.Expenses.Include(x => x.ExpensesCategory).Where(x => x.Title.Contains(sreach) || string.IsNullOrEmpty(sreach)).Skip(Skip).Take(Take).ToList();

            return mapper.Map<List<ExpensesDto>>(expensess);
        }

        //Get All To List
        public List<ExpensesDto> GetList()
        {
            var expensess = db.Expenses.ToList();
            return mapper.Map<List<ExpensesDto>>(expensess);
        }
        //Get One Expenses
        public ExpensesDto Get(int id)
        {
            var expenses = db.Expenses.SingleOrDefault(x => x.Id == id);
            return mapper.Map<ExpensesDto>(expenses);
        }

        //Create A New Expenses
        public async Task<int> Save(CreateExpensesDto dto)
        {
            var expenses = mapper.Map<ExpensesDbEntity>(dto);
            expenses.CreateAt = date;
            await db.Expenses.AddAsync(expenses);
            await db.SaveChangesAsync();
            return expenses.Id;
        }

        //Update A New Expenses
        public async Task<int> Update(UpdateExpensesDto dto)
        {
            var expenses = mapper.Map<ExpensesDbEntity>(dto);
            expenses.UpdateAt = date;
            db.Expenses.Update(expenses);
            await db.SaveChangesAsync();
            return expenses.Id;
        }

        //Delete Any Expenses
        public async Task Remove(int id)
        {
            var expenses = db.Expenses.SingleOrDefault(x => x.Id == id);
            expenses.IsDelete = true;
            db.Expenses.Update(expenses);
            await db.SaveChangesAsync();
        }
    }
}
