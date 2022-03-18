using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Cities
{
    public class UpdateCityDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int Id { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
