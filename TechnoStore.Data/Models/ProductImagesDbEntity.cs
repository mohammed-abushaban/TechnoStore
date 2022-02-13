using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
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
