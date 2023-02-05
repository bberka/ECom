using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.ApiModels.Request
{
    public class UpdateAdminAccountRequestModel : AuthRequestModelBase
    {
        public string EmailAddress { get; set; }
    }
}
