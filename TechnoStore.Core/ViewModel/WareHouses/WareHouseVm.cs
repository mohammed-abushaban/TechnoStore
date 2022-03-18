using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.ViewModel.WareHouses
{
    public class WareHouseVm : BaseVm
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longtude { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public string UserId { get; set; }

        public string CityName { get; set; }
        public string UserName { get; set; }

    }
}
