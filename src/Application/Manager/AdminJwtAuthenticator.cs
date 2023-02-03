using ECom.Infrastructure.Interfaces;

namespace ECom.Application.Manager
{
	public interface IAdminJwtAuthenticator : IJwtAuthentication
	{
	
	}

	public class AdminJwtAuthenticator : IAdminJwtAuthenticator
	{
		private readonly IAdminService _adminService;
		private readonly IOptionService _optionService;
		public readonly EasJWT _jwtManager;

		public AdminJwtAuthenticator(IAdminService adminService,IOptionService optionService)
		{
			this._adminService = adminService;
			this._optionService = optionService;
			var option = _optionService.GetJwtOption();
			_jwtManager = new(option.Secret, option.Issuer, option.Audience);
		}


		public ResultData<JwtTokenModel> Authenticate(LoginModel model)
		{
#if DEBUG
			var debugDic = new User().AsDictionary();
			debugDic.Add("AdminOnly", "");
			var debugToken = _jwtManager.GenerateJwtToken(debugDic, DateTime.Now.AddMinutes(720));
			var debugRes = new JwtTokenModel
			{
				ExpireUnix = DateTime.Now.AddMinutes(720).ToUnixTime(),
				RefreshToken = "",
				Token = debugToken,
			};
			return ResultData<JwtTokenModel>.Success(debugRes);
#endif
			var loginResult = _adminService.Login(model);
			if (!loginResult.IsSuccess)
			{
				return ResultData<JwtTokenModel>.Error(loginResult.Rv, loginResult.ErrorCode);
			}
			if (loginResult.Data is null) throw new InvalidDataException("LoginResult.Data can not be null");
			var adminAsDic = loginResult.Data.AsDictionary();
			adminAsDic.Add("AdminOnly", "");
			var option = _optionService.GetFullOptionCache().JwtOption;
			var expireMins = option.ExpireMinutesDefault;
			if (model.RememberMe) expireMins = option.ExpireMinutesLong;
			var date = DateTime.Now.AddMinutes(expireMins);
			var token = _jwtManager.GenerateJwtToken(adminAsDic, date);
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
