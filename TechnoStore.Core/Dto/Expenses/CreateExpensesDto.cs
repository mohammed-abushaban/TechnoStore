using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Expenses
{
    public class CreateExpensesDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public float Price { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Title { get; set; }
        public string Details { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int ExpensesCategoryId { get; set; }


    }
}
