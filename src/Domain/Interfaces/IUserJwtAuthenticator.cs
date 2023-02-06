using ECom.Domain.ApiModels.Request;
using ECom.Domain.ApiModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Interfaces
{
    public interface IUserJwtAuthenticator 
    {
        public ResultData<UserLoginResponseModel> Authenticate(LoginRequestModel model);
    }
}
