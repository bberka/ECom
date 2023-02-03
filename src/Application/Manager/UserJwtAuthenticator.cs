
using ECom.Domain.Entities;
using ECom.Infrastructure.Interfaces;


namespace ECom.Application.Manager
{
	public interface IUserJwtAuthenticator : IJwtAuthentication
	{

	}

	public class UserJwtAuthenticator : IUserJwtAuthenticator
	{
		private readonly IUserService _userService;
		private readonly IOptionService _optionService;
		public readonly EasJWT _jwtManager;
		public readonly JwtOption _jwtOption;

		public UserJwtAuthenticator(IUserService userService, IOptionService optionService)
		{
			this._userService = userService;
			this._optionService = optionService;
			_jwtOption = _optionService.GetJwtOption();
			_jwtManager = new(_jwtOption.Secret, _jwtOption.Issuer, _jwtOption.Audience);
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
			var expireMins = _jwtOption.ExpireMinutesDefault;
			if (model.RememberMe) expireMins = _jwtOption.ExpireMinutesLong;
			var date = DateTime.Now.AddMinutes(expireMins);
			var token = _jwtManager.GenerateJwtToken(userAsDic, date);
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
