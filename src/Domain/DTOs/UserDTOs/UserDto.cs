using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.DTOs.UserDTOs
{
    public class UserDto
    {
        //public UserDto(User user)
        //{
        //    Culture = user.Culture;
        //    Id = user.Id;
        //    TwoFactorType = user.TwoFactorType;
        //    FirstName = user.FirstName;
        //    LastName = user.LastName;
        //    IsEmailVerified = user.IsEmailVerified;
        //    TaxNumber = user.TaxNumber;
        //    EmailAddress = user.EmailAddress;
        //    PhoneNumber = user.PhoneNumber;
        //}
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public bool IsEmailVerified { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int? TaxNumber { get; set; }
        public byte TwoFactorType { get; set; } = 0;
        public string Culture { get; set; } = ConstantMgr.DefaultCulture;

    }

}
