using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Cities;
using TechnoStore.Core.ViewModel.Cities;

namespace TechnoStore.Infrastructure.Services.Cities
{
    public interface ICityService
    {
        List<CityVm> GetAll(string sreach, int page);
        List<CityVm> GetAll();
        CityVm Get(int id);
        Task<bool> Save(string userId, CreateCityDto dto);
        Task<bool> Update(string userId, UpdateCityDto dto);
        Task<bool> Remove(int id);
    }
}
