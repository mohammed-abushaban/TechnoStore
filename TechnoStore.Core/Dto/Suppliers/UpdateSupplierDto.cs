using System;
using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Suppliers
{
    public class UpdateSupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
