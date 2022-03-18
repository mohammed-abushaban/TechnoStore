using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Feedbacks
{
    public class CreateFeedbackDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Title { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(4000, ErrorMessage = Messages.Max4000)]
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(14, ErrorMessage = Messages.Max14)]
        public string Phone { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage), EmailAddress]
        public string Email { get; set; }
    }
}
