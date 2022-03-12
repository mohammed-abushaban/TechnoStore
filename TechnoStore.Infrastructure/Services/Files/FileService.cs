using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Infrastructure.Services.Files
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveFile(IFormFile file, string folderName)
        {
            string fileName = null;
            if (file != null && file.Length > 0)
            {
                //WWWRootPath/folderName/fileName
                var uploads = Path.Combine(_env.WebRootPath, folderName);
                fileName = Guid.NewGuid().ToString().Replace("-", "")
                           + Path.GetExtension(file.FileName);
                await using var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }

        public  bool DeleteFile(string path, string folderName)
        {
            //C:\ASP\MediaProductionCompany\MediaProductionCompany.API\wwwroot
            string fileToBeDeleted = Path.Combine(_env.WebRootPath, folderName, path);
            if ((System.IO.File.Exists(fileToBeDeleted)))
            {
                File.Delete(fileToBeDeleted);
                return true;
            }
            return false;
        }
    }
}
