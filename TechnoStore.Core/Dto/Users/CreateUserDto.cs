using System;
using System.ComponentModel.DataAnnotations;
using TechnoStore.Core.Constants;
using TechnoStore.Core.Enums;

namespace TechnoStore.Core.Dto.Users
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(25, ErrorMessage = Messages.Max25)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(25, ErrorMessage = Messages.Max25)]
        public string LastName { get; set; }


        [Required(ErrorMessage = Messages.ErrorMessage), EmailAddress]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string Email { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(25, ErrorMessage = Messages.Max25)]
        public string UserName { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [Phone, MaxLength(14, ErrorMessage = Messages.Max14)]
        public string PhoneNumber { get; set; }

        [StringLength(18, ErrorMessage = Messages.between, MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = Messages.password)]
        public string password { get; set; }

        [Required(ErrorMessage = Messages.ErrorMessage)]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        public UserType UserType { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? BirthDay { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(2000, ErrorMessage = Messages.Max2000)]
        public string Address { get; set; }
        public int? CityId { get; set; }
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(150, ErrorMessage = Messages.Max150)]
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }

        public bool IsDelete { get; set; } = false;
        [Required(ErrorMessage = Messages.ErrorMessage)]
        [MaxLength(10, ErrorMessage = Messages.Max10)]
        public string Zip_Code { get; set; }
        public bool Newsletter { get; set; }
    }
}
