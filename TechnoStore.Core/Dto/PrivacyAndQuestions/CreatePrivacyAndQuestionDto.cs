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
    public class CreatePrivacyAndQuestionDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string Privacy { get; set; }
        public string Question { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string TermsOfUse { get; set; }
    }
}
