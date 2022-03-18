using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Suppliers;
using TechnoStore.Core.ViewModel.Suppliers;

namespace TechnoStore.Infrastructure.Services.Suppliers
{
    public interface ISuppliersService
    {
        List<SupplierVm> GetAll(string sreach, int page);
        List<SupplierVm> GetAll();
        SupplierVm Get(int id);
        Task<bool> Save(string userId, CreateSupplierDto dto);
        Task<bool> Update(string userId, UpdateSupplierDto dto);
        Task<bool> Remove(int id);
    }
}
