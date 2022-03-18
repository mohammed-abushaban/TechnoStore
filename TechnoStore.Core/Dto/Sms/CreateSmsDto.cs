using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Sms
{
    public class CreateSmsDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string SendTo { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(14, ErrorMessage = Messages.Max14)]
        public string Phone { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string TextMessage { get; set; }
    }
}
