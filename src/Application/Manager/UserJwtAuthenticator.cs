﻿using ECom.Domain.Entities;
using System.Security.Claims;
using EasMe.Authorization;
using ECom.Domain.DTOs.UserDTOs;

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


        public ResultData<UserLoginResponse> Authenticate(LoginRequest model)
        {
            var loginResult = _userService.Login(model);
            if (!loginResult.IsSuccess)
            {
                return Result.Error(loginResult.Rv, loginResult.ErrorCode);
            }
            var userAsDic = loginResult.Data.AsDictionary();
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
                User = loginResult.Data,
                Token = jwtTokenModel
            };
        }
    }
}
