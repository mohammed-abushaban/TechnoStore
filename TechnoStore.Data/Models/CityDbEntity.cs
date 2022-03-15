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
    public class CityDbEntity : BaseEntity
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }

        public List<WarehouseDbEntity> Warehouses { get; set; }
        public List<UserDbEntity> Users { get; set; }
        //public List<SupplierDbEntity> Suppliers { get; set; }
    }
}
