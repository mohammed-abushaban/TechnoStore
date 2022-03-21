using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoStore.Core.Dto.PrivacyAndQuestions;
using TechnoStore.Core.ViewModel.PrivacyAndQuestions;

namespace TechnoStore.Infrastructure.Services.PrivacyAndQuestions
{
    public interface IPrivacyAndQuestionService
    {
        List<PrivacyAndQuestionVm> GetAll();
        PrivacyAndQuestionVm Get(int id);
        Task<int> Save(CreatePrivacyAndQuestionDto dto);
        Task<int> Update(UpdatePrivacyAndQuestionDto dto);
        Task<int> Remove(int id);
    }
}
