using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.DTOs
{
    public class LoginRequest
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        [IgnoreDataMember, Newtonsoft.Json.JsonIgnore, System.Text.Json.Serialization.JsonIgnore]
        public string EncryptedPassword => Password.ToEncryptedText();
    }
}
