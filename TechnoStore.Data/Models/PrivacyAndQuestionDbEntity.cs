using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Data.Models
{
    /*
     * سباسة الخصوصية تحفظ من sammrenote
     * الأسئلة الشائعة
     * شروط الاستخدام
     * 
     * جميع البيانات تحفظ في حقل واحد كصفحة HTML
     */
    public class PrivacyAndQuestionDbEntity : BaseEntity
    {

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string Privacy { get; set; }
        public string Question { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string TermsOfUse { get; set; }
    }
}
