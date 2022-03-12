using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.ViewModel.ExpensesCategories
{
    public class ExpensesCategoryVm : BaseVm
    {
        public string Name { get; set; }
    }
}
