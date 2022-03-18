using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Enums;

namespace TechnoStore.Core.ViewModel.Users
{
    public class UserVm
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public UserType UserType { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public bool IsDelete { get; set; } = false;
        public string Zip_Code { get; set; }
        public bool IsGeast { get; set; }
        public bool Newsletter { get; set; }
        public int? ShipperId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
