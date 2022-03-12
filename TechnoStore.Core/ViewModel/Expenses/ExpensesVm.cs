using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.ViewModel.Expenses
{
    public class ExpensesVm : BaseVm
    {
        public float Price { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int ExpensesCategoryId { get; set; }
        public string ExpensesCategoryName { get; set; }
    }
}
