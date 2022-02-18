using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Expenses;

namespace TechnoStore.Infrastructure.Services.Expenses
{
    public interface IExpensesService
    {
        List<ExpensesDto> GetAll(string sreach, int page);
        List<ExpensesDto> GetList();
        ExpensesDto Get(int id);
        Task<int> Save(CreateExpensesDto dto);
        Task<int> Update(UpdateExpensesDto dto);
        Task Remove(int id);
    }
}
