using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechnoStore.Core.Constants;

namespace TechnoStore.Data.Models
{
    /*
     * اسم الماركة
     * عن الماركة
     * شعار الماركة
     * 
     * علاقة مع جدول المنتجات
     */
    public class BrandDbEntity : BaseEntity
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName ="nvarchar(150)"),MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string About { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string ImageUrl { get; set; }

        public List<ProductDbEntity> Products { get; set; }
    }
}
