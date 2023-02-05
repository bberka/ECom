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

		public JwtTokenModel Authenticate(LoginRequestModel model)
		{
			var loginResult = _adminService.Login(model);
			var adminAsDic = loginResult.AsDictionary();
			adminAsDic.Add("AdminOnly", "");
			var expireMins = JwtOption.This.TokenExpireDefaultMinutes;
			if (model.RememberMe) expireMins = JwtOption.This.TokenExpireLongMinutes;
			var date = DateTime.Now.AddMinutes(expireMins);
			var token = _jwtManager.GenerateJwtToken(adminAsDic, date);
			var res = new JwtTokenModel
			{
				ExpireUnix = date.ToUnixTime(),
				RefreshToken = null,
				Token = token,
			};
			return res;
		}

		public string Refresh(string token)
		{
			throw new NotImplementedException();
		}

        
    }
}
