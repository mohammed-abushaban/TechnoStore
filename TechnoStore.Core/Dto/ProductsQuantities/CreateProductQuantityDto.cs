using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.ProductsQuantities
{
    public class CreateProductQuantityDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(25, ErrorMessage = Messages.Max25)]
        public string Color { get; set; }



    }
}
