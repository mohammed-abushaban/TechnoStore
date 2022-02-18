using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Data.Models
{
    /*
     * امتداد الصورة من ملف التخزين
     * رقم المنتج
     */
    public class ProductImagesDbEntity : BaseEntity
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int ProductId { get; set; }
        public ProductDbEntity Product { get; set; }
    }
}
