using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Users;
using TechnoStore.Core.Enums;
using TechnoStore.Core.ViewModel;
using TechnoStore.Core.ViewModel.Shippers;
using TechnoStore.Core.ViewModel.Users;

namespace TechnoStore.Infrastructure.Services.Users
{
    public interface IUserService
    {
        List<UserVm> GetAll(string search, int page, Gender? gender, UserType? userType);
        List<UserVm> GetAll();
        List<ShipperVm> GetAllShipper();
        UserVm Get(string id);
        Task<bool> Save(CreateUserDto dto, IFormFile image);
        Task<int> Remove(string id);
    }
}
