using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.ViewModel.Sms
{
    public class SmsVm : BaseVm
    {
        public string SendTo { get; set; }
        public string Phone { get; set; }
        public string TextMessage { get; set; }
    }
}
