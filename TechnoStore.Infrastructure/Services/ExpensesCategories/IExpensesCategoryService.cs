using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.ExpensesCategories;
using TechnoStore.Core.ViewModel.ExpensesCategories;

namespace TechnoStore.Infostructures.Services.ExpensesCategories
{
    public interface IExpensesCategoryService
    {
        List<ExpensesCategoryVm> GetAll(string sreach, int page);
        List<ExpensesCategoryVm> GetAll();
        ExpensesCategoryVm Get(int id);
        Task<int> Save(CreateExpensesCategoryDto dto);
        Task<int> Update(UpdateExpensesCategoryDto dto);
        Task<int> Remove(int id);
    }
}
