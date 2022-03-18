using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Enums;

namespace TechnoStore.Data.Models
{
    /*
     *الاسم الأول
     *الاسم الأخير
     *الجنس
     *نوع المستخدم
     *صورة المستخدم
     *تاريخ الميلاد
     *العنوان
     *المدينة
     *انشأ بواسطة
     *تاريخ الانشاء
     *تم التعديل بواسطة 
     *تاريخ التعديل
     *هل الحساب محذوف
     *كود المدينة
     *تسجيل من طرف الزبون أو مدخل مع عمليات الشراء بدون تسجيل
     *تفعيل النشرة البريدية
     *هل سجل البيانات كزائر أو مسجل مسبقا
     *شركات الشحن 
     *
     *علاقة مع سلة التسوق
     */
    public class UserDbEntity : IdentityUser
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(25)"), MaxLength(25, ErrorMessage = Messages.Max25)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(25)"), MaxLength(25, ErrorMessage = Messages.Max25)]
        public string LastName { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public Gender Gender { get; set; } // Eunms
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public UserType UserType { get; set; } // Eunms
        public string ImageUrl { get; set; }
        public DateTime? BirthDay { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(2000)"), MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string Address { get; set; }

        public int? CityId { get; set; }
        public CityDbEntity City { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool IsDelete { get; set; } = false;
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(10)"), MaxLength(10, ErrorMessage = Messages.Max10)]
        public string Zip_Code { get; set; }
        public bool IsGeast { get; set; } 
        public bool Newsletter { get; set; } 

        public List<CartDbEntity> Cart { get; set; }
    }
}
