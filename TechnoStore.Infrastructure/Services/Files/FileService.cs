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

        public async Task<bool> DeleteFile(string path)
        {
            //C:\ASP\MediaProductionCompany\MediaProductionCompany.API\wwwroot
            string fileToBeDeleted = Path.Combine(_env.WebRootPath, "PortfolioTranslationFiles\\", path);
            if ((System.IO.File.Exists(fileToBeDeleted)))
            {
                System.IO.File.Delete(fileToBeDeleted);
                return true;
            }
            return false;
        }
    }
}
