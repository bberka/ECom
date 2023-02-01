using EasMe.Extensions;
using ECom.Application.BaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
			var loginResult = AdminMgr.This.Login(model);
			if (!loginResult.IsSuccess)
			{
				return ResultData<JwtTokenModel>.Error(loginResult.Rv, loginResult.Response);
			}
			if (loginResult.Data is null) throw new InvalidDataException("LoginResult.Data can not be null");
			var adminAsDic = loginResult.Data.AsDictionary();
			adminAsDic.Add("AdminOnly","");
			var option = OptionMgr.This.GetSingle();
			var expireMins = option.JwtExpireMinutesDefault;
			if (model.RememberMe) expireMins = option.JwtExpireMinutesLong;
			var date = DateTime.Now.AddMinutes(expireMins);
			var token = JwtAuthenticator.This.Authenticator.GenerateJwtToken(adminAsDic, date);
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
