using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.Dto.Category
{
    public class UpdateCategoryDto
    {
        public int id { get; set; }
        public string UpdateBy { get; set; }
        public IFormFile Image { get; set; }
        public string About { get; set; }
        public string Name { get; set; }
    }
}
