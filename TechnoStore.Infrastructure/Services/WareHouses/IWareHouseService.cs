using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.WareHouse;
using TechnoStore.Core.ViewModel.Cities;
using TechnoStore.Core.ViewModel.Users;
using TechnoStore.Core.ViewModel.WareHouses;

namespace TechnoStore.Infrastructure.Services.WareHouse
{
    public interface IWareHouseService
    {
        List<WareHouseVm> GetAll(string search, int page);
        List<WareHouseVm> GetAll();
        List<CityVm> GetAllCities();
        List<UserVm> GetAllUsers();
        WareHouseVm Get(int id);
        Task<bool> Save(CreateWareHouseDto dto);
        Task<bool> Update(UpdateWareHouseDto dto);
        Task<bool> Remove(int id);
    }
}
