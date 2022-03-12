using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Expenses;
using TechnoStore.Core.ViewModel.Expenses;
using TechnoStore.Core.ViewModel.ExpensesCategories;

namespace TechnoStore.Infrastructure.Services.Expenses
{
    public interface IExpensesService
    {
        List<ExpensesVm> GetAll(string sreach, int page);
        List<ExpensesVm> GetAll();
        List<ExpensesCategoryVm> GetAllExpensesCategories();
        ExpensesVm Get(int id);
        Task<bool> Save(CreateExpensesDto dto);
        Task<int> Update(UpdateExpensesDto dto);
        Task Remove(int id);
    }
}
