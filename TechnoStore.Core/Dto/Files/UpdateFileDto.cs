﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TechnoStore.Core.Dto.Files
{
    public class UpdateFileDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Title { get; set; }
        public string AttachmentUrl { get; set; }
        [Column(TypeName = "nvarchar(150)"), MaxLength(150, ErrorMessage = Messages.Max150)]
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
