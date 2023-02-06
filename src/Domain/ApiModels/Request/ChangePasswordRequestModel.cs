using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.ApiModels.Request
{
    public class ChangePasswordRequestModel : AuthRequestModelBase
    {
        public string OldPassword { get; set; }
        public string EncryptedOldPassword { get => Convert.ToBase64String(OldPassword.MD5Hash()); }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
        public string EncryptedNewPassword { get => Convert.ToBase64String(NewPassword.MD5Hash()); }

    }
}
