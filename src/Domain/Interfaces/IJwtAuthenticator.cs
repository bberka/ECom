
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Domain.ApiModels.Request;

namespace ECom.Domain.Interfaces
{
    public interface IJwtAuthenticator
    {
        public JwtTokenModel Authenticate(LoginRequestModel model);
        public string Refresh(string token);
    }
}
