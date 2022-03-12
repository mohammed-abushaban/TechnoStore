using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechnoStore.Core.Constants;

namespace TechnoStore.Data.Models
{
    /*
     * اسم الشركة
     * عنوان الشركة
     * المدينة
     * رقم الجوال
     * البريد الالكتروني
     * صورة
     * العمولة
     * 
     * علاقة مع جدول الأوردرات
     */
    public class ShipperDbEntity : BaseEntity
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(2000)"), MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string Address { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(25)"), MaxLength(25, ErrorMessage = Messages.Max25)]
        public string City { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(14)"), MaxLength(14, ErrorMessage = Messages.Max14)]
        public string Phone { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage),EmailAddress]
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public float Commission { get; set; }

        public List<OrderDbEntity> Orders { get; set; }
    }
}
