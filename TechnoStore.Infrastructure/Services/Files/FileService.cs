
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Files;
using TechnoStore.Core.ViewModel.Files;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;


namespace TechnoStore.Infrastructure.Services.Files
{
    public class FileService : IFileService
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        DateTime date = DateTime.Now;
        public static double NumOfPages;
        private readonly IWebHostEnvironment _env;

        public FileService(ApplicationDbContext db, IMapper mapper, IWebHostEnvironment env)
        {
            _db = db;
            _mapper = mapper;
            _env = env;
        }




        //Get All File
        public List<FileVm> GetAll(string sreach, int page)
        {
            var NumOfExpCat = _db.Files
                .Count(x => x.Title.Contains(sreach) || string.IsNullOrEmpty(sreach));

            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page20 + 0.0));
            var Skip = (page - 1) * NumPages.page20;
            var Take = NumPages.page20;
            var files = _db.Files
                .Where(x => x.Title.Contains(sreach) || string.IsNullOrEmpty(sreach))
                .Skip(Skip).Take(Take).ToList();

            return _mapper.Map<List<FileVm>>(files);
        }

        //Get All To List
        public List<FileVm> GetAll()
        {
            var files = _db.Files.ToList();
            return _mapper.Map<List<FileVm>>(files);
        }

        //Get One File
        public FileVm Get(int id)
        {
            var file = _db.Files.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<FileVm>(file);
        }

        //Create A New File
        public async Task<int> Save(CreateFileDto dto)
        {
            if (_db.Files.Any(x => x.Title == dto.Title))
            {
                return 0;
            }
            var file = _mapper.Map<FileDbEntity>(dto);
            file.CreateAt = date;
            await _db.Files.AddAsync(file);
            await _db.SaveChangesAsync();
            return file.Id;
        }

        //Update A New File
        public async Task<int> Update(UpdateFileDto dto)
        {
            var file = _mapper.Map<FileDbEntity>(dto);
            file.UpdateAt = date;
            _db.Files.Update(file);
            await _db.SaveChangesAsync();
            return file.Id;
        }

        //Delete Any File
        public async Task<int> Remove(int id)
        {
            var file = _db.Files.SingleOrDefault(x => x.Id == id);
            foreach (var item in _db.Files.ToList())
            {
                if (file.Id == item.Id)
                {
                    return 0;
                }
            }
            file.IsDelete = true;
            _db.Files.Update(file);
            await _db.SaveChangesAsync();
            return file.Id;
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
