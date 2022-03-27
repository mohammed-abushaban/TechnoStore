using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Products
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(4000, ErrorMessage = Messages.Max4000)]
        public string Description { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public float PriceBuy { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public float PriceSale { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(10, ErrorMessage = Messages.Max10)]
        public string Code { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int BrandId { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int SubCategoryId { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int SupplierId { get; set; }

        public float Discount { get; set; } = 0;


        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int WarehouseId { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int Quantity { get; set; } = 0;
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Color { get; set; }
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Size { get; set; }
        [MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string ImageUrl { get; set; }

    }
}
