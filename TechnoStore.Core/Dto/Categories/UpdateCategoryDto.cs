using System;
using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Category
{
    public class UpdateCategoryDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int id { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string About { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string ImageUrl { get; set; }

        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string CreateBy { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
