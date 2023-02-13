using EasMe;
using EasMe.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.DTOs.Request
{
    public class RegisterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int? CitizenshipNumber { get; set; }
        public int? TaxNumber { get; set; }
        public int PreferredLangauge { get; set; }

        [IgnoreDataMember, Newtonsoft.Json.JsonIgnore, System.Text.Json.Serialization.JsonIgnore]
        public string EncryptedPassword => Password.ToEncryptedText();

        public User ToUserEntity()
        {
            return new User
            {
                CitizenShipNumber = CitizenshipNumber,
                RegisterDate = DateTime.Now,
                DeletedDate = null,
                EmailAddress = EmailAddress,
                PhoneNumber = PhoneNumber,
                Password = Convert.ToBase64String(Password.MD5Hash()),
                IsEmailVerified = false,
                IsValid = true,
                TaxNumber = TaxNumber,
                TwoFactorType = 0,
                Culture = "en",
                FirstName = FirstName,
                LastName = LastName,

            };
        }
    }
}
