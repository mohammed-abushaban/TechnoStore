using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Files
{
    public class CreateFileDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Title { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string AttachmentUrl { get; set; }
    }
}
