using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;

namespace TechnoStore.Core.Dto.Settings
{
    public class CreateSettingDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string NameOfWebsite { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string LogoUrl { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(4000, ErrorMessage = Messages.Max4000)]
        public string Vision { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(4000, ErrorMessage = Messages.Max4000)]
        public string Mission { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string Address { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage), MaxLength(4)]
        public int Year { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(4000, ErrorMessage = Messages.Max4000)]
        public string Features { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string FacebookUrl { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(14, ErrorMessage = Messages.Max14)]
        public string WhatsappNumber { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(14, ErrorMessage = Messages.Max14)]
        public string Phone { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string InstgramUrl { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(4000, ErrorMessage = Messages.Max4000)]
        public string AboutUs { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage), EmailAddress]
        [MaxLength(100, ErrorMessage = Messages.Max100)]
        public string Email { get; set; }
        public bool VisaIsActive { get; set; }
        public bool CashIsActive { get; set; }
        public bool OnStoreIsActive { get; set; }
        public bool WholeSaleIsActive { get; set; }
    }
}
