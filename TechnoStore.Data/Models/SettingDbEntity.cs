using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechnoStore.Core.Constants;

namespace TechnoStore.Data.Models
{
    /*
     * اسم الموقع
     * شعار الموقع
     * الرؤية
     * الرسالة
     * سنة التأسيس
     * مميزات الموقع
     * رابط الفيس
     * رقم الواتساب
     * رقم التواصل
     * رابط الانستفرام
     * شرح عن الموقع
     * 
     * دفع بالفيزا فعال
     * دفع بالكاش عند الاستلام فعال
     * دفع في المخزن فعال
     * بيع بالجملة من الآدمن فقط فعال
     */
    public class SettingDbEntity : BaseEntity
    {
        public SettingDbEntity()
        {
            VisaIsActive = true;
            CashIsActive = true;
            OnStoreIsActive = true;
            WholeSaleIsActive = true;
        }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150,ErrorMessage =Messages.Max150)]
        public string NameOfWebsite { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(2000)"), MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string LogoUrl { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(4000)"), MaxLength(4000, ErrorMessage = Messages.Max4000)]
        public string Vision { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(4000)"), MaxLength(4000, ErrorMessage = Messages.Max4000)]
        public string Mission { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(2000)"), MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string Address { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage), MaxLength(4)]
        public int Year { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(4000)"), MaxLength(4000, ErrorMessage = Messages.Max4000)]
        public string Features { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(2000)"), MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string FacebookUrl { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(14)"), MaxLength(14, ErrorMessage = Messages.Max14)]
        public string WhatsappNumber { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(14)"), MaxLength(14, ErrorMessage = Messages.Max14)]
        public string Phone { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string InstgramUrl { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(4000)"), MaxLength(4000, ErrorMessage = Messages.Max4000)]
        public string AboutUs { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage),EmailAddress]
        [Column(TypeName = "nvarchar(100)"), MaxLength(100, ErrorMessage = Messages.Max100)]
        public string Email { get; set; }

        public bool VisaIsActive { get; set; }
        public bool CashIsActive { get; set; }
        public bool OnStoreIsActive { get; set; }
        public bool WholeSaleIsActive { get; set; }
    }
}
