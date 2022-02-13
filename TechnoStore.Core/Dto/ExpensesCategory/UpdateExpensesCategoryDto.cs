using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.Dto.ExpensesCategory
{
    public class UpdateExpensesCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }

        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
