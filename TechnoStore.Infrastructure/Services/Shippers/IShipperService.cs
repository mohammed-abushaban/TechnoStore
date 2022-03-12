using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Shippers;
using TechnoStore.Core.ViewModel.Shippers;

namespace TechnoStore.Infrastructure.Services.Shippers
{
    public interface IShipperService
    {
        List<ShipperVm> GetAll(string sreach, int page);
        List<ShipperVm> GetAll();
        ShipperVm Get(int id);
        Task<bool> Save(CreateShipperDto dto, IFormFile image);
        Task<int> Update(UpdateShipperDto dto, IFormFile image);
        Task<bool> Remove(int id);
    }
}
