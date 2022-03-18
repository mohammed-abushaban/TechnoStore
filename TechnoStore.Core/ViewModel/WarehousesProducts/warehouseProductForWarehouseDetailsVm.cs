using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.ViewModel.WarehousesProducts
{
    public class warehouseProductForWarehouseDetailsVm
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<ProductDetailsForWarehouseDetailsVm> productDetails { get; set; }
    }
}
