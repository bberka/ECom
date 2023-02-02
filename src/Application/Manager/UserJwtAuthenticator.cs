﻿namespace ECom.Application.Manager
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
			var loginResult = UserDal.This.Login(model);
			if (!loginResult.IsSuccess)
			{
				return ResultData<JwtTokenModel>.Error(loginResult.Rv, loginResult.Response);
			}
			if (loginResult.Data is null) throw new InvalidDataException("LoginResult.Data can not be null");
			var userAsDic = loginResult.Data.AsDictionary();
			userAsDic.Add("UserOnly","");
			var option = OptionDal.This.GetSingle();
			var expireMins = option.JwtExpireMinutesDefault;
			if (model.RememberMe) expireMins = option.JwtExpireMinutesLong;
			var date = DateTime.Now.AddMinutes(expireMins);
			var token = JwtAuthenticator.This.Authenticator.GenerateJwtToken(userAsDic, date);
			var res = new JwtTokenModel
			{
				ExpireUnix = date.ToUnixTime(),
				RefreshToken = null,
				Token = token,
			};
			if (option.IsUseRefreshToken)
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
