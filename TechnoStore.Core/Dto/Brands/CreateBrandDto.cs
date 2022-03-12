using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Brands
{
    public class CreateBrandDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string About { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string ImageUrl { get; set; }
    }
}
