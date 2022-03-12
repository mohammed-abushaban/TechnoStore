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

        //Get All Feedbacks
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
        
        //Get All To List
        public List<FeedbackVm> GetAll()
        {
            var feedbacks = _db.Feedbacks.ToList();
            return _mapper.Map<List<FeedbackVm>>(feedbacks);
        }

        //Get One Feedback
        public FeedbackVm Get(int id)
        {
            var feedback = _db.Feedbacks.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<FeedbackVm>(feedback);
        }

        //Create A New Feedback
        public async Task<int> Save(CreateFeedbackDto dto)
        {
            if (_db.Feedbacks.Any(x => x.Title == dto.Title))
            {
                return 0;
            }
            var feedback = _mapper.Map<FeedbackDbEntity>(dto);
            feedback.CreateAt = date;
            await _db.Feedbacks.AddAsync(feedback);
            await _db.SaveChangesAsync();
            return feedback.Id;
        }

        //Delete Any feedback
        public async Task<int> Remove(int id)
        {
            var feedback = _db.Feedbacks.SingleOrDefault(x => x.Id == id);
            foreach (var item in _db.Feedbacks.ToList())
            {
                if (feedback.Id == item.Id)
                {
                    return 0;
                }
            }
            feedback.IsDelete = true;
            _db.Feedbacks.Update(feedback);
            await _db.SaveChangesAsync();
            return feedback.Id;
        }
    }
}
