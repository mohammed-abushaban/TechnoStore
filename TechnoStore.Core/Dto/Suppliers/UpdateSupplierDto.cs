﻿using System;
using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Suppliers
{
    public class UpdateSupplierDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int Id { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(14, ErrorMessage = Messages.Max14)]
        public string Phone { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string Address { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int CityId { get; set; }

        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
