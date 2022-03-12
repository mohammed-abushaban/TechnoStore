using System;
using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.ProductsQuantities
{
    public class UpdateProductQuantityDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int Id { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(25, ErrorMessage = Messages.Max25)]
        public string Color { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int ProductId { get; set; }

        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
