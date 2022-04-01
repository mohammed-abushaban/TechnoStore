using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Files;
using TechnoStore.Core.ViewModel.Files;

namespace TechnoStore.Infrastructure.Services.Files
{
    public interface IFileService
    {

        List<FileVm> GetAll(string sreach, int page);
        List<FileVm> GetAll();
        FileVm Get(int id);
        Task<int> Save(CreateFileDto dto, IFormFile attachment);
        Task<int> Update(UpdateFileDto dto, IFormFile attachment);
        Task<int> Remove(int id);

        Task<string> SaveFile(IFormFile file, string folderName);
        bool DeleteFile(string path, string folderName);

    }
}
