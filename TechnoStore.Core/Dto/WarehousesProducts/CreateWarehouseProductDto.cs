using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using Xunit;

namespace TechnoStore.Core.Dto.WarehousesProducts
{
    public class CreateWarehouseProductDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int WarehouseId { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int Quantity { get; set; } = 0;
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Color { get; set; }
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Size { get; set; }
        public string ImageUrl { get; set; }
    }
}
