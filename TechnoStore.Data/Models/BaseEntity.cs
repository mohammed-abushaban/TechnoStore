using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechnoStore.Core.Constants;

namespace TechnoStore.Data.Models
{
    /*
     * جدول يرث منه كافة الجداول ما عدا اليوزر والإعدادت
     * اي دي لكل جدول
     * اسم المستخدم الذي أنشأ العنصر
     * وقت الانشاء
     * اسم المستخدم الذي عدل العنصر
     * وقت التعديل
     * حذف من الواجهة مع البقاء في القاعدة
     */
    public class BaseEntity
    {

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool IsDelete { get; set; } = false;
    }

}
