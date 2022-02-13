using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.ExpensesCategory;

namespace TechnoStore.Infostructures.Services.ExpensesCategory
{
    public interface IExpensesCategoryService
    {
        List<ExpensesCategoryDto> GetAll(string sreach, int page);
        ExpensesCategoryDto Get(int id);
        Task<int> Save(CreateExpensesCategoryDto dto);
        Task<int> Update(UpdateExpensesCategoryDto dto);
        Task Remove(int id);
    }
}
