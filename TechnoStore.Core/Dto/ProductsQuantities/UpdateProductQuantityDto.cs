using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.Dto.ProductsQuantities
{
    public class UpdateProductQuantityDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public int ProductId { get; set; }
    }
}
