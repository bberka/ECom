﻿using EasMe;
using EasMe.Extensions;
using ECom.Application.Manager;
using ECom.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
		private readonly static EasLog logger = EasLogFactory.CreateLogger(nameof(AuthController));
		private readonly IUserService _userService;

		public AuthController(IUserService userService)
		{
			this._userService = userService;
		}
		[HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
			var res = UserJwtAuthenticator.This.Authenticate(model);
			if (!res.IsSuccess)
			{
				logger.Warn($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
				return BadRequest(res);
			}
			logger.Info($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
			return Ok(res);
		}
		[HttpPost]
		public IActionResult Register([FromBody] RegisterModel model)
		{
			var res = _userService.Register(model);
			if (!res.IsSuccess)
			{
				logger.Warn($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
				return BadRequest(res);
			}
			logger.Info($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
			return Ok(res);
		}
	}
}