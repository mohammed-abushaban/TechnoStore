using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechnoStore.Core.Constants;

namespace TechnoStore.Data.Models
{
    /*
     * عنوان الرفق
     * امتداد الملف المرفق
     */
    public class FileDbEntity : BaseEntity
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Title { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string AttachmentUrl { get; set; }
    }
}
