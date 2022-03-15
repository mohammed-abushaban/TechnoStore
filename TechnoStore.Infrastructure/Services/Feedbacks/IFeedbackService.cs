using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.Feedbacks;
using TechnoStore.Core.ViewModel.Feedbacks;

namespace TechnoStore.Infostructures.Services.IFeedbacks
{
    public interface IFeedbackService
    {
        List<FeedbackVm> GetAll(string sreach, int page);
        List<FeedbackVm> GetAll();
        FeedbackVm Get(int id);
        Task<bool> Save(CreateFeedbackDto dto);
        Task<int> Remove(int id);
    }
}
