using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Sms;
using TechnoStore.Core.ViewModel.Sms;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;

namespace TechnoStore.Infrastructure.Services.Sms
{
    public class SmsService : ISmsService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        DateTime date = DateTime.Now;
        public static double NumOfPages;

        public SmsService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        //Get All Sms To List With or Without Paramrtar
        public List<SmsVm> GetAll(string sreach, int page)
        {
            var NumOfExpCat = _db.Sms
                .Count(x => x.SendTo.Contains(sreach) || string.IsNullOrEmpty(sreach));

            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page100 + 0.0));
            var Skip = (page - 1) * NumPages.page100;
            var Take = NumPages.page100;
            var sms = _db.Sms
                .Where(x => x.SendTo.Contains(sreach) || string.IsNullOrEmpty(sreach))
                .Skip(Skip).Take(Take).ToList();

            return _mapper.Map<List<SmsVm>>(sms);
        }

        //Get All Sms Without Parametar
        public List<SmsVm> GetAll()
        {
            var sms = _db.Sms.ToList();
            return _mapper.Map<List<SmsVm>>(sms);
        }


        //Create A New Sms
        public async Task<int> Save(CreateSmsDto dto)
        {
            var sms = _mapper.Map<SmsDbEntity>(dto);
            sms.CreateAt = date;
            sms.CreateBy = "Test";
            await _db.Sms.AddAsync(sms);
            await _db.SaveChangesAsync();
            return sms.Id;
        }


    }
}
