
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Interfaces
{
    public interface IJwtAuthenticator
    {
        public ResultData<JwtTokenModel> Authenticate(LoginModel model);
        public ResultData<string> Refresh(string token);
    }


}
