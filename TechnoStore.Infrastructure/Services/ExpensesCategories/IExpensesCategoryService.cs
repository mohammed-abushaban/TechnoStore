using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.ExpensesCategories;

namespace TechnoStore.Infostructures.Services.ExpensesCategories
{
    public interface IExpensesCategoryService
    {
        List<ExpensesCategoryDto> GetAll(string sreach, int page);
        List<ExpensesCategoryDto> GetList();
        ExpensesCategoryDto Get(int id);
        Task<int> Save(CreateExpensesCategoryDto dto);
        Task<int> Update(UpdateExpensesCategoryDto dto);
        Task Remove(int id);
    }
}
