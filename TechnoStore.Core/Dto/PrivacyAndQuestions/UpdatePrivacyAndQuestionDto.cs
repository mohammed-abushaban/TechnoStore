using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.PrivacyAndQuestions
{
    public class UpdatePrivacyAndQuestionDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string Privacy { get; set; }
        public string Question { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string TermsOfUse { get; set; }
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
