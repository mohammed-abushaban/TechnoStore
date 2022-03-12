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
        List<SettingVm> GetAll();
        SettingVm Get(int id);
        Task<int> Save(CreateSettingDto dto);
        Task<int> Update(UpdateSettingDto dto);
    }
}
