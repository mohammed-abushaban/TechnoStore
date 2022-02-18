using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;


namespace TechnoStore.Data.Models
{
    /*
     * الكمية
     * كوكيز المتصفح لليوزر غير المسجل
     * يوزر الزبون في حال التصفح مع تسجيل الدخول
     * 
     * علاقة مع جدول الأوردرات
     * علاقة مع جدول المنتجات في سلة المشتريات
     */
    public class CartDbEntity : BaseEntity
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int Quantity { get; set; }
        public string Cookies { get; set; }
        public int? UserId { get; set; }
        public UserDbEntity User { get; set; }

        public List<OrderDbEntity> Orders { get; set; }
        public List<CartProductDbEntity> CartProducts { get; set; }
    }
}
