using AutoMapper;
using TechnoStore.Core.Dto.Expenses;
using TechnoStore.Core.Dto.ExpensesCategories;
using TechnoStore.Core.ViewModel.Expenses;
using TechnoStore.Core.ViewModel.ExpensesCategories;
using TechnoStore.Data.Models;

namespace TechnoStore.Infostructures.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //ExpensesCategory
            CreateMap<ExpensesCategoryDbEntity, ExpensesCategoryVm>();
            CreateMap<CreateExpensesCategoryDto, ExpensesCategoryDbEntity>();
            CreateMap<UpdateExpensesCategoryDto, ExpensesCategoryDbEntity>();

            //Expenses
            CreateMap<ExpensesDbEntity, ExpensesVm>();
            CreateMap<CreateExpensesDto, ExpensesDbEntity>();
            CreateMap<UpdateExpensesDto, ExpensesDbEntity>();
        }

    }
}
