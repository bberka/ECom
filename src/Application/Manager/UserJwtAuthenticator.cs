
using ECom.Infrastructure.Interfaces;


namespace ECom.Application.Manager
{
    public class UserJwtAuthenticator : IJwtAuthentication
	{
		private UserJwtAuthenticator() { }
		public static UserJwtAuthenticator This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static UserJwtAuthenticator? Instance;

		public ResultData<JwtTokenModel> Authenticate(LoginModel model)
		{
#if DEBUG
			var debugDic = new User().AsDictionary();
			debugDic.Add("UserOnly", "");
			var debugToken = JwtAuthenticator.This.Authenticator.GenerateJwtToken(debugDic, DateTime.Now.AddMinutes(720));
			var debugRes = new JwtTokenModel
			{
				ExpireUnix = DateTime.Now.AddMinutes(720).ToUnixTime(),
				RefreshToken = "",
				Token = debugToken,
			};
			return ResultData<JwtTokenModel>.Success(debugRes);
#endif
			var userService = ServiceProviderProxy.This.GetService<IUserService>();
			var optionService = ServiceProviderProxy.This.GetService<IOptionService>();
			var loginResult = userService.Login(model);
			if (!loginResult.IsSuccess)
			{
				return ResultData<JwtTokenModel>.Error(loginResult.Rv, loginResult.ErrorCode);
			}
			if (loginResult.Data is null) throw new InvalidDataException("LoginResult.Data can not be null");
			var userAsDic = loginResult.Data.AsDictionary();
			userAsDic.Add("UserOnly","");
			var option = optionService.GetFromCache();
			var jwtOptionService = ServiceProviderProxy.This.GetService<IJwtOptionService>().GetFromCache();
			var expireMins = jwtOptionService.ExpireMinutesDefault;
			if (model.RememberMe) expireMins = jwtOptionService.ExpireMinutesLong;
			var date = DateTime.Now.AddMinutes(expireMins);
			var token = JwtAuthenticator.This.Authenticator.GenerateJwtToken(userAsDic, date);
			var res = new JwtTokenModel
			{
				ExpireUnix = date.ToUnixTime(),
				RefreshToken = null,
				Token = token,
			};
			if (jwtOptionService.IsUseRefreshToken)
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
