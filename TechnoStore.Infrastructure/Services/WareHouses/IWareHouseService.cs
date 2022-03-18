using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.WareHouse;
using TechnoStore.Core.ViewModel.WareHouses;

namespace TechnoStore.Infrastructure.Services.WareHouse
{
    public interface IWareHouseService
    {
        List<WareHouseVm> GetAll(string search, int page);
        List<WareHouseVm> GetAll();
        WareHouseVm Get(int id);
        Task<bool> Save(string userId, CreateWareHouseDto dto);
        Task<bool> Update(string userId, UpdateWareHouseDto dto);
        Task<bool> Remove(int id);
    }
}
