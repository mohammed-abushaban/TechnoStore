using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;

namespace TechnoStore.Data.Models
{
    /*
     * رقم تعريف المخزن
     * رقم تعريف المنتج
     * كمية المنتج
     * لون المنتج
     * حجم المنتج
     * صورة المنتج
     */
    public class WarehouseProductDbEntity : BaseEntity
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int WarehouseId { get; set; }
        public WarehouseDbEntity Warehouse { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int ProductId { get; set; }
        public ProductDbEntity Product { get; set; }


        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int Quantity { get; set; } = 0;
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Color { get; set; }
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Size { get; set; }
        [Column(TypeName = "nvarchar(2000)"), MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string ImageUrl { get; set; }

    }
}
