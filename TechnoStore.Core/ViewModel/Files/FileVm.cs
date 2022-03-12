using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Core.ViewModel.Files
{
    public class FileVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AttachmentUrl { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
