using AutoMapper;
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

namespace TechnoStore.Infrastructure.Services.Settings
{
    public class SettingService : ISettingService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        DateTime date = DateTime.Now;
        public static double NumOfPages;

        public SettingService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        //Get All To List
        public List<SettingVm> GetAll()
        {
            var setting = _db.Settings.ToList();
            return _mapper.Map<List<SettingVm>>(setting);
        }

        //Get One Setting
        public SettingVm Get(int id)
        {
            var setting = _db.Settings.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<SettingVm>(setting);
        }

        //Create A New Setting
        public async Task<int> Save(CreateSettingDto dto)
        {
            if (_db.Settings.Any(x => x.NameOfWebsite == dto.NameOfWebsite))
            {
                return 0;
            }
            var setting = _mapper.Map<SettingDbEntity>(dto);
            setting.CreateAt = date;
            await _db.Settings.AddAsync(setting);
            await _db.SaveChangesAsync();
            return setting.Id;
        }

        //Update A New Setting
        public async Task<int> Update(UpdateSettingDto dto)
        {
            var setting = _mapper.Map<SettingDbEntity>(dto);
            setting.UpdateAt = date;
            _db.Settings.Update(setting);
            await _db.SaveChangesAsync();
            return setting.Id;
        }

    }
}
