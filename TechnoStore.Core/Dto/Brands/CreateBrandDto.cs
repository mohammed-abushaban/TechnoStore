using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.Dto.Brands
{
    public class CreateBrandDto
    {
        public string Name { get; set; }
        public string About { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
