using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.ViewModel.PrivacyAndQuestions
{
    public class PrivacyAndQuestionVm
    {
        public int Id { get; set; }
        public string Privacy { get; set; }
        public string Question { get; set; }
        public string TermsOfUse { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
