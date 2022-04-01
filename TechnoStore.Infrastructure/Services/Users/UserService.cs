using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Dto.Users;
using TechnoStore.Core.Enums;
using TechnoStore.Core.ViewModel.Cities;
using TechnoStore.Core.ViewModel.Users;
using TechnoStore.Data.Data;
using TechnoStore.Data.Models;
using TechnoStore.Infrastructure.Services.Files;

namespace TechnoStore.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly UserManager<UserDbEntity> _userManager;

        DateTime date = DateTime.Now;
        public static double NumOfPages;

        public UserService(ApplicationDbContext db
                          , IMapper mapper , IFileService fileService
                          , UserManager<UserDbEntity> userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
        }

        //Get All Users To List With or Without Paramrtar
        public List<UserVm> GetAll(string search, int page, Gender? gender, UserType? userType)
        {
            var NumOfExpCat = _db.Users
                .Count(x => x.UserName.Contains(search) 
                || x.PhoneNumber.Contains(search) || string.IsNullOrEmpty(search) 
                && (x.Gender == gender || gender == null) 
                && (x.UserType == userType || userType == null));



            NumOfPages = Math.Ceiling(NumOfExpCat / (NumPages.page20 + 0.0));
            var Skip = (page - 1) * NumPages.page20;
            var Take = NumPages.page20;

            var users = _db.Users.Include(x => x.City)
                .Where(x => x.UserName.Contains(search)
                || x.PhoneNumber.Contains(search) || string.IsNullOrEmpty(search)
                && (x.Gender == gender || gender == null)
                && (x.UserType == userType || userType == null))
                .Skip(Skip).Take(Take).ToList();

            return _mapper.Map<List<UserVm>>(users);
        }

        //Get All Users Without Parametar
        public List<UserVm> GetAll()
        {
            return _mapper.Map<List<UserVm>>(_db.Users.ToList());
        }

        //Get All Cities Without Parametar
        public List<CityVm> GetAllCities()
        {
            return _mapper.Map<List<CityVm>>(_db.Cities.ToList());
        }

        //Get One User By Id
        public UserVm Get(string id)
        {
            return _mapper.Map<UserVm>(_db.Users.Include(x => x.City).SingleOrDefault(x => x.Id == id));
        }

        //Add A new User On Database
        public async Task<bool> Save(CreateUserDto dto, IFormFile image)
        {
            if (_db.Users.Any(x => x.UserName == dto.UserName && x.Email == dto.Email))
            {
                return false;
            }
            dto.CreateAt = date;
            dto.CreateBy = "Test";
            var x = await _fileService.SaveFile(image, "Images/UsersImages");
            dto.ImageUrl = x;
            dto.UserName = dto.Email;
            var user = _mapper.Map<UserDbEntity>(dto);

            var result = await _userManager.CreateAsync(user, dto.password);
            if (result.Succeeded)
            {
                //إعطاء الصلاحيات
                if (user.UserType == UserType.Admin)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                else if(user.UserType == UserType.User)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
                else if(user.UserType == UserType.Customer)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "Shipper");
                }
            }
            await _db.SaveChangesAsync();
            return true;
        }

        //Remove User | Soft Delete | IsDelete = true
        public async Task<int> Remove(string id)
        {

            if (_db.Users.Count() <= 1)
            {
                return 0;
            }
            else
            {
                var user = _db.Users.SingleOrDefault(x => x.Id == id);
                var users = GetAll();
                int admin = 0, shipper = 0;

                foreach (var item in users)
                {
                    if (item.UserType == UserType.Admin)
                    {
                        admin += 1;
                    }
                    if(item.UserType == UserType.Shipper)
                    {
                        shipper += 1;
                    }
                }

                if (admin <= 1 && user.UserType == UserType.Admin)
                {
                    return 1;
                }
                else if (shipper <= 1)
                {
                    return 2;
                }
                else
                {
                    user.IsDelete = true;
                    _db.Users.Update(user);
                    await _db.SaveChangesAsync();
                    return 4;
                }
                //اذا كان اليوزر المراد حذفه نفس اليوزر الحالي لا يمكن الحذف
                //if (user.UserName == Users)
                //{
                //    return 3;
                //}
            }            
        }
    }
}
