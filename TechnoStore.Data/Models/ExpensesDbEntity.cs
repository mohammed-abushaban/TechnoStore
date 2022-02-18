using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechnoStore.Core.Constants;

namespace TechnoStore.Data.Models
{
    /*
     * مبلغ المصروف
     * عنوان المصروف
     * تفاصيل المصروف
     * تصنيف المصروف
     */
    public class ExpensesDbEntity : BaseEntity
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public float Price { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Title { get; set; }
        public string Details { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int ExpensesCategoryId { get; set; }
        public ExpensesCategoryDbEntity ExpensesCategory { get; set; }
    }
}
