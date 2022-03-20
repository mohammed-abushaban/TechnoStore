using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Enums;

namespace TechnoStore.Data.Models
{
    /*
     * اسم الموظف
     * رقم الهوية
     * العنوان
     * رقم التواصل
     * تاريخ الميلاد
     * الجنس
     * المهنة
     * سنوات الخبرة
     * الرقم الوظيفي
     * تاريخ بدء العمل
     * ساعات العمل
     * المرتب
     */
    public class EmployeeDbEntity : BaseEntity
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(9)"), MaxLength(9, ErrorMessage = Messages.Max9)]
        public string NumPerId { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Address { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(14)"), MaxLength(14, ErrorMessage = Messages.Max14)]
        public string Phone { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public DateTime Birth { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public Gender Gender { get; set; } // Eunms
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Career { get; set; }
        public int? GradYear { get; set; }
        [Column(TypeName = "nvarchar(10)"), MaxLength(10, ErrorMessage = Messages.Max10)]
        public string JobNum { get; set; }
        public int? YearOfExp { get; set; }
        public DateTime? StartWork { get; set; }
        public int? WorkHours { get; set; }
        public int? Salary { get; set; }

    }
}
