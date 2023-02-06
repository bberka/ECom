
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
		public ResultData<JwtTokenModel> Authenticate(LoginRequestModel model)
		{
			var loginResult = _userService.Login(model);
            if (!loginResult.IsSuccess)
            {
                return ResultData<JwtTokenModel>.Error(loginResult.Rv, (ErrorCode)(object)loginResult.ErrorString, loginResult.Parameters);
            }
            var userAsDic = loginResult.AsDictionary();
			userAsDic.Add("UserOnly", "");
			var expireMins = JwtOption.This.TokenExpireMinutes;
			var date = DateTime.Now.AddMinutes(expireMins);
			var token = _jwtManager.GenerateJwtToken(userAsDic, date);
			var res = new JwtTokenModel
			{
				ExpireUnix = date.ToUnixTime(),
				Token = token,
			};
			return res;
		}


      
    }
}
