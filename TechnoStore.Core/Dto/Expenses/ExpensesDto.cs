using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.Dto.Expenses
{
    public class ExpensesDto
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int ExpensesCategoryId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool IsDelete { get; set; }
    }
}
