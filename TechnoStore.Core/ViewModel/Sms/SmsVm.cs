using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.ViewModel.Sms
{
    public class SmsVm
    {
        public int Id { get; set; }
        public string SendTo { get; set; }
        public string Phone { get; set; }
        public string TextMessage { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
