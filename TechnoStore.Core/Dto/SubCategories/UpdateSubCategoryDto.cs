using System;
using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.SubCategories
{
    public class UpdateSubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
