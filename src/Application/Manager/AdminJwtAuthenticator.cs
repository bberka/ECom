using ECom.Infrastructure.Interfaces;

namespace ECom.Application.Manager
{
	public class AdminJwtAuthenticator : IJwtAuthentication
	{
		private AdminJwtAuthenticator() { }
		public static AdminJwtAuthenticator This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static AdminJwtAuthenticator? Instance;

		public ResultData<JwtTokenModel> Authenticate(LoginModel model)
		{
#if DEBUG
			var debugDic = new User().AsDictionary();
			debugDic.Add("AdminOnly", "");
			var debugToken = JwtAuthenticator.This.Authenticator.GenerateJwtToken(debugDic, DateTime.Now.AddMinutes(720));
			var debugRes = new JwtTokenModel
			{
				ExpireUnix = DateTime.Now.AddMinutes(720).ToUnixTime(),
				RefreshToken = "",
				Token = debugToken,
			};
			return ResultData<JwtTokenModel>.Success(debugRes);
#endif
			var adminService = ServiceProviderProxy.This.GetService<IAdminService>();
			var optionService = ServiceProviderProxy.This.GetService<IOptionService>();
			var loginResult = adminService.Login(model);
			if (!loginResult.IsSuccess)
			{
				return ResultData<JwtTokenModel>.Error(loginResult.Rv, loginResult.ErrorCode);
			}
			if (loginResult.Data is null) throw new InvalidDataException("LoginResult.Data can not be null");
			var adminAsDic = loginResult.Data.AsDictionary();
			adminAsDic.Add("AdminOnly","");
			var option = optionService.GetFromCache();
			var jwtOption = ServiceProviderProxy.This.GetService<IJwtOptionService>().GetFromCache();
			var expireMins = jwtOption.ExpireMinutesDefault;
			if (model.RememberMe) expireMins = jwtOption.ExpireMinutesLong;
			var date = DateTime.Now.AddMinutes(expireMins);
			var token = JwtAuthenticator.This.Authenticator.GenerateJwtToken(adminAsDic, date);
			var res = new JwtTokenModel
			{
				ExpireUnix = date.ToUnixTime(),
				RefreshToken = null,
				Token = token,
			};
			if (jwtOption.IsUseRefreshToken)
			{
				//TODO:
				throw new NotImplementedException();
			}
			return ResultData<JwtTokenModel>.Success(res);
		}

		public ResultData<string> Refresh(string token)
		{
			throw new NotImplementedException();
		}
	}
}
