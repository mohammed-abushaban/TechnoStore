using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Settings;
using TechnoStore.Core.ViewModel.Settings;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;
using TechnoStore.Infrastructure.Services.Files;

namespace TechnoStore.Infrastructure.Services.Settings
{
    public class SettingService : ISettingService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        DateTime date = DateTime.Now;
        public static double NumOfPages;

        public SettingService(ApplicationDbContext db, IMapper mapper,IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
        }


        //Get All To List
        public SettingVm GetSetting()
        {
            return _mapper.Map<SettingVm>(_db.Settings.FirstOrDefault());
        }
        //Create A New Setting
        public async Task<int> Save(CreateSettingDto dto, IFormFile logo)
        {
            var setting = _mapper.Map<SettingDbEntity>(dto);
            setting.CreateAt = date;
            setting.CreateBy = "Test";
            var x = await _fileService.SaveFile(logo, "Images/Logo");
            setting.LogoUrl = x;
            await _db.Settings.AddAsync(setting);
            await _db.SaveChangesAsync();
            return setting.Id;
        }

        //Update A New Setting
        public async Task<int> Update(CreateSettingDto dto, IFormFile logo)
        {
            var setting = _mapper.Map<SettingDbEntity>(dto);
            setting.UpdateAt = date;
            setting.CreateBy = "Test1";
            if (logo != null)
            {
                if (setting.LogoUrl != null)
                {
                    _fileService.DeleteFile(setting.LogoUrl, "Images/Logo");
                }
                var x = await _fileService.SaveFile(logo, "Images/Logo");
                setting.LogoUrl = x;
            }
            _db.Settings.Update(setting);
            await _db.SaveChangesAsync();
            return setting.Id;
        }

    }
}
