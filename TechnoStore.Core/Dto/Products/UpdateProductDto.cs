using System;
using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Products
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float PriceBuy { get; set; }
        public float PriceSale { get; set; }
        public string Code { get; set; }
        public int BrandId { get; set; }
        public int SubCategoryId { get; set; }
        public int SupplierId { get; set; }
        public float? Discount { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
