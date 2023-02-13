using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.DTOs.Request
{
    public class UpdateAdminAccountRequest : AuthRequestModelBase
    {
        public string EmailAddress { get; set; }
    }
}
