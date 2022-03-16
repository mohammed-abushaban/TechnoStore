using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechnoStore.Core.Constants;

namespace TechnoStore.Data.Models
{
    /*
     * كود المنتج تلقائي
     * تاريخ الوصول المتوقع
     * هل الطلب مكتمل
     * هل استلمت شركة الشحن المنتج
     * سبب الإرجاع إن وجد
     * إجمالي سعر الطلب / الفاتورة
     * شركة الشحن والتوصيل
     * رقم سلة التسوق
     */
    public class OrderDbEntity : BaseEntity
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(10)"), MaxLength(10, ErrorMessage = Messages.Max10)]
        public string OrderCode { get; set; }
        public DateTime CompleteDate { get; set; }
        public bool IsAccept { get; set; } = false; //للمناقشة
        public bool IsDone { get; set; } = false;
        [Column(TypeName = "nvarchar(2000)"), MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string ReasonrReturn { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public float TotalPrice { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int CartId { get; set; }
        public CartDbEntity Cart { get; set; }
    }
}
