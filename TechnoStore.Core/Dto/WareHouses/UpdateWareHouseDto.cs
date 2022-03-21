using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.Dto.WareHouse
{
    public class UpdateWareHouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longtude { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; } 
        public string UserId { get; set; }
    }
}
