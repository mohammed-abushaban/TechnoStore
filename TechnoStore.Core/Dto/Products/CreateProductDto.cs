using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.Dto.Products
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float PriceBuy { get; set; }
        public float PriceSale { get; set; }
        public string Code { get; set; }
        public int BrandId { get; set; }
        public int SubCategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
