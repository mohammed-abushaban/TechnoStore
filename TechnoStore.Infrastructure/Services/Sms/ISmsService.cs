using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Sms;
using TechnoStore.Core.ViewModel.Sms;

namespace TechnoStore.Infrastructure.Services.Sms
{
    public interface ISmsService
    {
        List<SmsVm> GetAll(string sreach, int page);
        List<SmsVm> GetAll();
        Task<int> Save(CreateSmsDto dto);
        //Task SendAll();
    }
}
