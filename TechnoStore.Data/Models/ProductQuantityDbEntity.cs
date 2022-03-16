using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechnoStore.Core.Constants;

namespace TechnoStore.Data.Models
{
    /*
     * الكمية
     * اللون
     * 
     * رقم المنتج
     * 
     * الجدول قابل لإضافة أي تفاصيل أخرى
     */
    public class ProductQuantityDbEntity : BaseEntity
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int Quantity { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(25)"), MaxLength(25, ErrorMessage = Messages.Max25)]
        public string Color { get; set; }
    }
}
