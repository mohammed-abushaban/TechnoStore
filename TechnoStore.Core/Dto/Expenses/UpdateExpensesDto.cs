﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Expenses
{
    public class UpdateExpensesDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public float Price { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Title { get; set; }
        public string Details { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public int ExpensesCategoryId { get; set; }
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
