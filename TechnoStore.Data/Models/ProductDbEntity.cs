using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechnoStore.Core.Constants;

namespace TechnoStore.Data.Models
{
    /*
     * اسم المنتج
     * وصف المنتج
     * مجموعة الصور
     * سعر الشراء
     * سعر البيع للزبون
     * تقييم المنتج من الزبون
     * كود المنتج
     * خصم إن وجد
     * متاح أو انتهت الكمية
     * الماركة 
     * التصنيف 
     * شركة التوريد
     * 
     * علاقة مع جدول البضاعة التالفة
     * علاقة مع جدول الصور
     * علاقة مع جدول الكميات
     * علاقة مع سلة التسوق
     */
    public class ProductDbEntity : BaseEntity  
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(4000)"), MaxLength(4000, ErrorMessage = Messages.Max4000)]
        public string Description { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public float PriceBuy { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public float PriceSale { get; set; }
        public float? Evaluation { get; set; } //تقييم رقمي
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(10)"), MaxLength(10, ErrorMessage = Messages.Max10)]
        public string Code { get; set; }
        public float Discount { get; set; } = 0;
        public bool IsAvalable { get; set; } = false;

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int BrandId { get; set; }
        public BrandDbEntity Brand { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int SubCategoryId { get; set; }
        public SubCategoryDbEntity SubCategory { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int SupplierId { get; set; }
        public SupplierDbEntity Supplier { get; set; }


        public List<ProductDamageDbEntity> ProductDamages { get; set; }
        public List<ProductImagesDbEntity> ProductImages { get; set; }
        public List<CartProductDbEntity> CartProducts { get; set; }
        public List<WarehouseProductDbEntity> WarehouseProducts { get; set; }

    }
}
