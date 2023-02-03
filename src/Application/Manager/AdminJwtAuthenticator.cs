using ECom.Infrastructure.Interfaces;

namespace ECom.Application.Manager
{
	public interface IAdminJwtAuthenticator : IJwtAuthenticator
	{
	
	}

	public class AdminJwtAuthenticator : IAdminJwtAuthenticator
	{
		private readonly IAdminService _adminService;
		private readonly IOptionService _optionService;
		private readonly EasJWT _jwtManager;
		private readonly JwtOption _jwtOption;
		public AdminJwtAuthenticator(IAdminService adminService,IOptionService optionService)
		{
			this._adminService = adminService;
			this._optionService = optionService;
			_jwtOption = _optionService.GetJwtOption();
			_jwtManager = new(_jwtOption.Secret, _jwtOption.Issuer, _jwtOption.Audience);
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
			var expireMins = _jwtOption.ExpireMinutesDefault;
			if (model.RememberMe) expireMins = _jwtOption.ExpireMinutesLong;
			var date = DateTime.Now.AddMinutes(expireMins);
			var token = _jwtManager.GenerateJwtToken(adminAsDic, date);
			var res = new JwtTokenModel
			{
				ExpireUnix = date.ToUnixTime(),
				RefreshToken = null,
				Token = token,
			};
			if (_jwtOption.IsUseRefreshToken)
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
