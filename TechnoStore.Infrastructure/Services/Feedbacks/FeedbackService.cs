using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Feedbacks;
using TechnoStore.Core.ViewModel.Feedbacks;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infostructures.Services.IFeedbacks
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        DateTime date = DateTime.Now;
        public static double NumOfPages;

        public FeedbackService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        //Get All Feedbacks To List With or Without Paramrtar
        public List<FeedbackVm> GetAll(string sreach, int page)
        {
            var NumOfExpCat = _db.Feedbacks
                .Count(x => x.Title.Contains(sreach) || string.IsNullOrEmpty(sreach));

            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page20 + 0.0));
            var Skip = (page - 1) * NumPages.page20;
            var Take = NumPages.page20;
            var feedbacks = _db.Feedbacks
                .Where(x => x.Title.Contains(sreach) || string.IsNullOrEmpty(sreach))
                .Skip(Skip).Take(Take).ToList();

            return _mapper.Map<List<FeedbackVm>>(feedbacks);
        }

        //Get All Feedbacks Without Parametar
        public List<FeedbackVm> GetAll()
        {
            return _mapper.Map<List<FeedbackVm>>(_db.Feedbacks.ToList());
        }

        //Get One Feedback By Id
        public FeedbackVm Get(int id)
        {
            return _mapper.Map<FeedbackVm>(_db.Feedbacks.SingleOrDefault(x => x.Id == id));
        }

        //Add A new Feedback On Database
        public async Task<bool> Save(CreateFeedbackDto dto)
        {
            var feedback = _mapper.Map<FeedbackDbEntity>(dto);
            feedback.CreateAt = date;
            feedback.CreateBy = "Test";
            await _db.Feedbacks.AddAsync(feedback);
            await _db.SaveChangesAsync();
            return true;
        }

        //Remove Feedback | Soft Delete | IsDelete = true
        public async Task<int> Remove(int id)
        {
            var feedback = _db.Feedbacks.SingleOrDefault(x => x.Id == id);
            feedback.IsDelete = true;
            _db.Feedbacks.Update(feedback);
            await _db.SaveChangesAsync();
            return feedback.Id;
        }
    }
}
