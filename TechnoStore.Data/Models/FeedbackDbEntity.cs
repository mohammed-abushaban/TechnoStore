using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechnoStore.Core.Constants;

namespace TechnoStore.Data.Models
{
    /*
     * العنوان
     * التفاصيل
     * صورة
     * رقم تواصل
     * ايميل
     */
    public class FeedbackDbEntity : BaseEntity 
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Title { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(4000)"), MaxLength(4000, ErrorMessage = Messages.Max4000)]
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(14)"), MaxLength(14, ErrorMessage = Messages.Max14)]
        public string  Phone { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage), EmailAddress]
        public string Email { get; set; }
    }
}
