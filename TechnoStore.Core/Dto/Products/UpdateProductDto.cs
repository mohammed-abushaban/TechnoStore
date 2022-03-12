using System;
using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Products
{
    public class UpdateProductDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int Id { get; set; }

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


        public float? Evaluation { get; set; } //تقييم رقمي
        public float? Discount { get; set; }
        public bool IsAvalable { get; set; }

        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
