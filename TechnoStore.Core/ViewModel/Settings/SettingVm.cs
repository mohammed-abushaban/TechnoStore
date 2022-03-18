using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.ViewModel.Settings
{
    public class SettingVm : BaseVm
    {
        public string NameOfWebsite { get; set; }
        public string LogoUrl { get; set; }
        public string Vision { get; set; }
        public string Mission { get; set; }
        public string Address { get; set; }
        public int Year { get; set; }
        public string Features { get; set; }
        public string FacebookUrl { get; set; }
        public string WhatsappNumber { get; set; }
        public string Phone { get; set; }
        public string InstgramUrl { get; set; }
        public string AboutUs { get; set; }
        public string Email { get; set; }
        public bool VisaIsActive { get; set; }
        public bool CashIsActive { get; set; }
        public bool OnStoreIsActive { get; set; }
        public bool WholeSaleIsActive { get; set; }
    }
}
