
using ECom.Infrastructure.Interfaces;


namespace ECom.Application.Manager
{
	public interface IUserJwtAuthenticator : IJwtAuthentication
	{

	}

	public class UserJwtAuthenticator : IUserJwtAuthenticator
	{
		private readonly IUserService _userService;
		private readonly IJwtOptionService _jwtOptionService;
		public readonly EasJWT _jwtManager;

		public UserJwtAuthenticator(IUserService userService, IJwtOptionService jwtOptionService)
		{
			this._userService = userService;
			this._jwtOptionService = jwtOptionService;
			var option = _jwtOptionService.GetFromCache();
			_jwtManager = new(option.Secret, option.Issuer, option.Audience);
		}
		public ResultData<JwtTokenModel> Authenticate(LoginModel model)
		{
#if DEBUG
			var debugDic = new User().AsDictionary();
			debugDic.Add("UserOnly", "");
			var debugToken = _jwtManager.GenerateJwtToken(debugDic, DateTime.Now.AddMinutes(720));
			var debugRes = new JwtTokenModel
			{
				ExpireUnix = DateTime.Now.AddMinutes(720).ToUnixTime(),
				RefreshToken = "",
				Token = debugToken,
			};
			return ResultData<JwtTokenModel>.Success(debugRes);
#endif
			var loginResult = _userService.Login(model);
			if (!loginResult.IsSuccess)
			{
				return ResultData<JwtTokenModel>.Error(loginResult.Rv, loginResult.ErrorCode);
			}
			if (loginResult.Data is null) throw new InvalidDataException("LoginResult.Data can not be null");
			var userAsDic = loginResult.Data.AsDictionary();
			userAsDic.Add("UserOnly", "");
			var option = _jwtOptionService.GetFromCache();
			var expireMins = option.ExpireMinutesDefault;
			if (model.RememberMe) expireMins = option.ExpireMinutesLong;
			var date = DateTime.Now.AddMinutes(expireMins);
			var token = _jwtManager.GenerateJwtToken(userAsDic, date);
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
