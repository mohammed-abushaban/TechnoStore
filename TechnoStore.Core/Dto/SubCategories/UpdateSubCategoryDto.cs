using System;
using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.SubCategories
{
    public class UpdateSubCategoryDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int Id { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int CategoryId { get; set; }

        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
