using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.ViewModel.SubCategories
{
    public class SubCategoryVm
    {
        public int Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
