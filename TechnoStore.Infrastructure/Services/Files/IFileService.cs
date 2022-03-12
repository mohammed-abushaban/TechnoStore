using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Files;
using TechnoStore.Core.ViewModel.Files;
using TechnoStore.Data.Data;

namespace TechnoStore.Infrastructure.Services.Files
{
    public interface IFileService
    {
        List<FileVm> GetAll(string sreach, int page);
        List<FileVm> GetAll();
        FileVm Get(int id);
        Task<int> Save(CreateFileDto dto);
        Task<int> Update(UpdateFileDto dto);
        Task<int> Remove(int id);

    }
}
