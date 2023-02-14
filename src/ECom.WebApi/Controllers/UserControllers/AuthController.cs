using EasMe;
using EasMe.Extensions;
using ECom.Application.Manager;
using ECom.Application.Services;
using ECom.Application.Validators;
using ECom.Domain.DTOs;
using ECom.Domain.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace ECom.WebApi.Controllers.UserControllers
{

    [AllowAnonymous]
    public class AuthController : BaseUserController
    {
		private readonly IUserService _userService;
		private readonly IUserJwtAuthenticator _userJwtAuthenticator;
        private readonly ILogService _logService;

        public AuthController(
			IUserService userService,
			IUserJwtAuthenticator userJwtAuthenticator,
            ILogService logService)
		{
			this._userService = userService;
			this._userJwtAuthenticator = userJwtAuthenticator;
            _logService = logService;
        }

		[HttpPost]
		public ActionResult<ResultData<UserLoginResponse>> Login([FromBody] LoginRequest model)
		{
            var res = _userJwtAuthenticator.Authenticate(model);
			_logService.UserLog(res.ToResult(),null,"Auth.Login",model.EmailAddress,model.EncryptedPassword);
            return res.WithoutRv();
        }

		[HttpPost]
		public ActionResult<Result> Register([FromBody] RegisterUserRequest model)
		{
			var res = _userService.Register(model);
            _logService.UserLog(res, null, "Auth.Register", model.EmailAddress);
			return res.WithoutRv();
		}
	}
}
