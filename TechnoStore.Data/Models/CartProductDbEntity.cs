using TechnoStore.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
 

namespace TechnoStore.Data.Models
{
    /*
     * رقم المنتج
     * رقم السلة
     * 
     * حتى تتمكن السلة الواحدة من الاتساع لأكثر من منتج
     */
    public class CartProductDbEntity : BaseEntity
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int ProductId { get; set; }
        public ProductDbEntity Product { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int CartId { get; set; }
        public CartDbEntity Cart { get; set; }
    }
}
