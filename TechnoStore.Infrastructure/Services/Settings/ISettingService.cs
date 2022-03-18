﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Settings;
using TechnoStore.Core.ViewModel.Settings;

namespace TechnoStore.Infrastructure.Services.Settings
{
    public interface ISettingService
    {
        SettingVm GetSetting();
        Task<int> Save(CreateSettingDto dto, IFormFile logo);
        Task<int> Update(CreateSettingDto dto, IFormFile logo);
    }
}
