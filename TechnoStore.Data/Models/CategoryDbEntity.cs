﻿using System;
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
     * عن التصنيف
     * صورة التصنيف
     * 
     * علاقة مع جدول التصنيفات الفرعية
     */
    public class CategoryDbEntity : BaseEntity
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Name { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string About { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public string ImageUrl { get; set; }

        public List<SubCategoryDbEntity> SubCategories { get; set; }
    }
}