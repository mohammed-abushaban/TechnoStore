using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;

namespace TechnoStore.Data.Models
{
    /*
     * اسم التصنيف
     * 
     *  علاقة مع جدول المصروفات 
     */
    public class ExpensesCategoryDbEntity : BaseEntity
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }

        public List<ExpensesDbEntity> Expenses { get; set; }
    }
}
