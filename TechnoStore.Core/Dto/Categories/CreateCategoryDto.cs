using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.Dto.Category
{
    public class CreateCategoryDto
    {
        public string CreateBy { get; set; }
        public IFormFile Image { get; set; }

        public string About { get; set; }
        public string Name { get; set; }

    }
}
