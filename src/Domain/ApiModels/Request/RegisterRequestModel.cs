using EasMe;
using EasMe.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.ApiModels.Request
{
    public class RegisterRequestModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int? CitizenshipNumber { get; set; }
        public int? TaxNumber { get; set; }
        public int PreferredLangauge { get; set; }


        public User ToUserEntity()
        {
            return new User
            {
                CitizenShipNumber = CitizenshipNumber,
                RegisterDate = DateTime.Now,
                DeletedDate = null,
                EmailAddress = EmailAddress,
                PhoneNumber = PhoneNumber,
                FailedPasswordCount = 0,
                Password = Convert.ToBase64String(Password.MD5Hash()),
                IsEmailVerified = false,
                IsValid = true,
                IsTestAccount = false,
                TaxNumber = TaxNumber,
                TwoFactorType = 0,
                TotalLoginCount = 0,
                PreferredLanguageId = 1,
                Name = Name,
                Surname = Surname,

            };
        }
    }
}
