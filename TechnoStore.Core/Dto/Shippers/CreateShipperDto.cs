using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Shippers
{
    public class CreateShipperDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string Address { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(25, ErrorMessage = Messages.Max25)]
        public string City { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(14, ErrorMessage = Messages.Max14)]
        public string Phone { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage), EmailAddress]
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public float Commission { get; set; }
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
