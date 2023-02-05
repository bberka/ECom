using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.ApiModels.Request
{
    public class AddAdminRequestModel
    {
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        public Admin ToAdminEntity()
        {
            return new Admin
            {
                RegisterDate = DateTime.Now,
                DeletedDate = null,
                EmailAddress = EmailAddress,
                FailedPasswordCount = 0,
                Password = Convert.ToBase64String(Password.MD5Hash()),
                IsEmailVerified = false,
                IsValid = true,
                IsTestAccount = false,
                TwoFactorType = 0,
                TotalLoginCount = 0,

            };
        }
    }
}
