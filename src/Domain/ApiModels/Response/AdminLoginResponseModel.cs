using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.ApiModels.Response
{
    public class AdminLoginResponseModel
    {
        public AdminNecessaryInfo Admin { get; set; }
        public JwtTokenModel Token { get; set; }
    }
}
