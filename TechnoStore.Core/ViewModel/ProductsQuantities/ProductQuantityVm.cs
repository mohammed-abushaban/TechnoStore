using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.ViewModel.ProductsQuantities
{
    public class ProductQuantityVm : BaseVm
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public int ProductId { get; set; }

    }
}
