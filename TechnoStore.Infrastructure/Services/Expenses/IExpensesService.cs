using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Expenses;

namespace TechnoStore.Infrastructure.Services.Expenses
{
    public interface IExpensesService
    {
        List<ExpensesDto> GetAll(string sreach, int page);
        ExpensesDto Get(int id);
        Task<int> Save(CreateExpensesDto dto);
        Task<int> Update(UpdateExpensesDto dto);
        Task Remove(int id);
    }
}
