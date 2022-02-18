using System;
using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.ExpensesCategories
{
    public class ExpensesCategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
