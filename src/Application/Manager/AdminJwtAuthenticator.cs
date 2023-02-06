using ECom.Domain.ApiModels.Request;
using ECom.Domain.Interfaces;


namespace ECom.Application.Manager
{

	public class AdminJwtAuthenticator : IAdminJwtAuthenticator
	{
		private readonly IAdminService _adminService;
		private readonly EasJWT _jwtManager;
		public AdminJwtAuthenticator(IAdminService adminService)
		{
			this._adminService = adminService;
			_jwtManager = new(JwtOption.This.Secret, JwtOption.This.Issuer, JwtOption.This.Audience);
		}

	

        public ResultData<AdminLoginResponseModel> Authenticate(LoginRequestModel model)
        {
            var loginResult = _adminService.Login(model);
            if (!loginResult.IsSuccess)
            {
                return ResultData<AdminLoginResponseModel>.Error(loginResult.Rv, (ErrorCode)(object)loginResult.ErrorString, loginResult.Parameters);
            }
            var adminAsDic = loginResult.AsDictionary();
            adminAsDic.Add("AdminOnly", "");
            var expireMins = JwtOption.This.TokenExpireMinutes;
            var date = DateTime.Now.AddMinutes(expireMins);
            var token = _jwtManager.GenerateJwtToken(adminAsDic, date);
            var res = new JwtTokenModel
            {
                ExpireUnix = date.ToUnixTime(),
                Token = token,
            };
            var jwtTokenModel = new JwtTokenModel
            {
                ExpireUnix = date.ToUnixTime(),
                Token = token,
            };
            return new AdminLoginResponseModel
            {
                Admin = loginResult.Data,
                Token = jwtTokenModel
            };
        }
    }
}
