using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.ViewModel.WarehousesProducts
{
    public class WarehouseProductDetailsVm : BaseVm
    {
        public string Name { get; set; }
        public int TotalQuantity { get; set; }
        public List<wareHouseForProductDetailsVm> wareHousesVm { get; set; }
    }
}
