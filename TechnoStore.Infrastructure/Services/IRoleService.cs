using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoStore.Infrastructure.Services
{
    public interface IRoleService
    {
        Task<string> InitRole();
    }
}
