
using ECom.Domain.ApiModels.Request;
using ECom.Domain.Entities;
using ECom.Domain.Interfaces;


namespace ECom.Application.Manager
{

	public class UserJwtAuthenticator : IUserJwtAuthenticator
	{
		private readonly IUserService _userService;
		private readonly IOptionService _optionService;
		public readonly EasJWT _jwtManager;

		public UserJwtAuthenticator(IUserService userService, IOptionService optionService)
		{
			this._userService = userService;
			this._optionService = optionService;
			_jwtManager = new(JwtOption.This.Secret, JwtOption.This.Issuer, JwtOption.This.Audience);
		}
		public JwtTokenModel Authenticate(LoginRequestModel model)
		{
			var loginResult = _userService.Login(model);
			var userAsDic = loginResult.AsDictionary();
			userAsDic.Add("UserOnly", "");
			var expireMins = JwtOption.This.TokenExpireDefaultMinutes;
			if (model.RememberMe) expireMins = JwtOption.This.TokenExpireLongMinutes;
			var date = DateTime.Now.AddMinutes(expireMins);
			var token = _jwtManager.GenerateJwtToken(userAsDic, date);
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
