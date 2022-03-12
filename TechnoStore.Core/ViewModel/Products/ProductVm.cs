using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.ViewModel.Products
{
    public class ProductVm : BaseVm
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float PriceBuy { get; set; }
        public float PriceSale { get; set; }
        public float PriceAfterDiscount { get; set; }
        public float? Evaluation { get; set; } //تقييم رقمي
        public string Code { get; set; }
        public float? Discount { get; set; }
        public bool IsAvalable { get; set; }
        public int BrandId { get; set; }
        public int SubCategoryId { get; set; }
        public int SupplierId { get; set; }
        public string BrandName { get; set; }
        public string SubCategoryName { get; set; }
        public string SupplierName { get; set; }

    }
}
