using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.WareHouse
{
    public class CreateWareHouseDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string Address { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public double Latitude { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public double Longtude { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(14, ErrorMessage = Messages.Max14)]
        public string Phone { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int CityId { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string UserId { get; set; }
    }
}
