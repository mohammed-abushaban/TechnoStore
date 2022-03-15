using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.PrivacyAndQuestions;
using TechnoStore.Core.ViewModel.PrivacyAndQuestions;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infrastructure.Services.PrivacyAndQuestions
{
    public class PrivacyAndQuestionService : IPrivacyAndQuestionService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        DateTime date = DateTime.Now;

        public PrivacyAndQuestionService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        //Get All To List
        public List<PrivacyAndQuestionVm> GetAll()
        {
            var privacyAndQuestion = _db.PrivacyAndQuestions.ToList();
            return _mapper.Map<List<PrivacyAndQuestionVm>>(privacyAndQuestion);
        }

        //Get One PrivacyAndQuestion
        public PrivacyAndQuestionVm Get(int id)
        {
            var privacyAndQuestion = _db.Sms.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<PrivacyAndQuestionVm>(privacyAndQuestion);
        }

        //Create A New PrivacyAndQuestion
        public async Task<int> Save(CreatePrivacyAndQuestionDto dto)
        {
            var privacyAndQuestion = _mapper.Map<PrivacyAndQuestionDbEntity>(dto);
            privacyAndQuestion.CreateAt = date;
            privacyAndQuestion.UpdateBy = "Test";
            await _db.PrivacyAndQuestions.AddAsync(privacyAndQuestion);
            await _db.SaveChangesAsync();
            return privacyAndQuestion.Id;
        }

        //Update A New PrivacyAndQuestion
        public async Task<int> Update(UpdatePrivacyAndQuestionDto dto)
        {
            var privacyAndQuestion = _mapper.Map<PrivacyAndQuestionDbEntity>(dto);
            privacyAndQuestion.UpdateAt = date;
            privacyAndQuestion.UpdateBy = "Test1";
            _db.PrivacyAndQuestions.Update(privacyAndQuestion);
            await _db.SaveChangesAsync();
            return privacyAndQuestion.Id;
        }

        //Delete Any PrivacyAndQuestion
        public async Task<int> Remove(int id)
        {
            var privacyAndQuestion = _db.PrivacyAndQuestions.SingleOrDefault(x => x.Id == id);
            privacyAndQuestion.IsDelete = true;
            _db.PrivacyAndQuestions.Update(privacyAndQuestion);
            await _db.SaveChangesAsync();
            return privacyAndQuestion.Id;
        }
    }
}
