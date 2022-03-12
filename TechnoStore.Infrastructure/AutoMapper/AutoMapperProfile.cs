using AutoMapper;
using TechnoStore.Core.Dto.Expenses;
using TechnoStore.Core.Dto.ExpensesCategories;
using TechnoStore.Core.Dto.Feedbacks;
using TechnoStore.Core.Dto.Files;
using TechnoStore.Core.Dto.PrivacyAndQuestions;
using TechnoStore.Core.Dto.Settings;
using TechnoStore.Core.Dto.Sms;
using TechnoStore.Core.ViewModel.Expenses;
using TechnoStore.Core.ViewModel.ExpensesCategories;
using TechnoStore.Core.ViewModel.Feedbacks;
using TechnoStore.Core.ViewModel.Files;
using TechnoStore.Core.ViewModel.PrivacyAndQuestions;
using TechnoStore.Core.ViewModel.Settings;
using TechnoStore.Core.ViewModel.Sms;
using TechnoStore.Data.Models;

namespace TechnoStore.Infostructures.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //ExpensesCategory
            CreateMap<ExpensesCategoryDbEntity, ExpensesCategoryVm>();
            CreateMap<CreateExpensesCategoryDto, ExpensesCategoryDbEntity>();
            CreateMap<UpdateExpensesCategoryDto, ExpensesCategoryDbEntity>();

            //Expenses
            CreateMap<ExpensesDbEntity, ExpensesVm>();
            CreateMap<CreateExpensesDto, ExpensesDbEntity>();
            CreateMap<UpdateExpensesDto, ExpensesDbEntity>();

            //Feedback
            CreateMap<FeedbackDbEntity, FeedbackVm>();
            CreateMap<CreateFeedbackDto, FeedbackDbEntity>();
            CreateMap<UpdateFeedbackDto, FeedbackDbEntity>();

            //File
            CreateMap<FileDbEntity, FileVm>();
            CreateMap<CreateFileDto, FileDbEntity>();
            CreateMap<UpdateFileDto, FileDbEntity>();

            //Sms
            CreateMap<SmsDbEntity, SmsVm>();
            CreateMap<CreateSmsDto, SmsDbEntity>();
            CreateMap<UpdateSmsDto, SmsDbEntity>();

            //PrivacyAndQuestion 
            CreateMap<PrivacyAndQuestionDbEntity, PrivacyAndQuestionVm>();
            CreateMap<CreatePrivacyAndQuestionDto, PrivacyAndQuestionDbEntity>();
            CreateMap<UpdatePrivacyAndQuestionDto, PrivacyAndQuestionDbEntity>();

            //Setting  
            CreateMap<SettingDbEntity, SettingVm>();
            CreateMap<CreateSettingDto, SettingDbEntity>();
            CreateMap<UpdateSettingDto, SettingDbEntity>();

        }

    }
}
