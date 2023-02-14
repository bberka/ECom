using ECom.Domain.Entities;
using System.Security.Claims;
using EasMe.Authorization;
using ECom.Domain.DTOs.UserDTOs;
using static ECom.Domain.Results.DomainResult;

namespace ECom.Application.Manager
{

    public class UserJwtAuthenticator : IUserJwtAuthenticator
	{
		private readonly IUserService _userService;
        private readonly IDebugService _debugService;
        public readonly EasJWT _jwtManager;

		public UserJwtAuthenticator(
            IUserService userService, 
            IDebugService debugService)
		{
			this._userService = userService;
            _debugService = debugService;
            _jwtManager = new(JwtOption.This.Secret, JwtOption.This.Issuer, JwtOption.This.Audience);
		}


        public ResultData<UserLoginResponse> Authenticate(LoginRequest model)
        {
#if DEBUG
            var user = _debugService.GetUserDto();
#else
            var loginResult = _userService.Login(model);
            if (!loginResult.IsSuccess)
            {
                return Result.Error(loginResult.Rv, loginResult.ErrorCode);
            }
            var user = loginResult.Data;
#endif
            var userAsDic = user.AsDictionary();
            var remove = userAsDic.Where(x => x.Value == null || x.Value.ToString() == "");
            foreach (var kvp in remove)
            {
                userAsDic.Remove(kvp.Key);
            }
            userAsDic.Add("UserOnly", "true");
            userAsDic.Add(ClaimTypes.Role, "User");
            var expireMins = JwtOption.This.TokenExpireMinutes;
            var date = DateTime.UtcNow.AddMinutes(expireMins);
            var token = _jwtManager.GenerateJwtToken(userAsDic, date);
            var jwtTokenModel = new JwtToken
            {
                ExpireUnix = date.ToUnixTime(),
                Token = token,
            };
            return new UserLoginResponse
            {
                User = user,
                Token = jwtTokenModel
            };
        }
    }
}
