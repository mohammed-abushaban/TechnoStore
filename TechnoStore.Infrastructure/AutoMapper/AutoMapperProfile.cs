using AutoMapper;
using TechnoStore.Core.Dto.ExpensesCategory;
using TechnoStore.Data.Models;

namespace TechnoStore.Infostructures.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //ExpensesCategory For Example
            CreateMap<ExpensesCategoryDbEntity, ExpensesCategoryDto>();
            CreateMap<CreateExpensesCategoryDto, ExpensesCategoryDbEntity>();
            CreateMap<UpdateExpensesCategoryDto, ExpensesCategoryDbEntity>();
        }

    }
}
