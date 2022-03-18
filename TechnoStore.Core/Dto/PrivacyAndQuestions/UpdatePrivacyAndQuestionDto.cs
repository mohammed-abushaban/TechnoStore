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
        public string Privacy { get; set; }
        public string Question { get; set; }
        public string TermsOfUse { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
