using EasMe;
using EasMe.Extensions;
using ECom.Application.Manager;
using ECom.Application.Services;
using ECom.Domain.ApiModels.Request;
using ECom.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
		private readonly static EasLog logger = EasLogFactory.CreateLogger(nameof(AuthController));
		private readonly IUserService _userService;
		private readonly IUserJwtAuthenticator _userJwtAuthenticator;
		private readonly IAuthenticator<User> _authenticator;

		public AuthController(
			IUserService userService,
			IUserJwtAuthenticator userJwtAuthenticator,
			IAuthenticator<User> authenticator)
		{
			this._userService = userService;
			this._userJwtAuthenticator = userJwtAuthenticator;
			this._authenticator = authenticator;
		}
		[HttpPost]
		public IActionResult Login([FromBody] LoginRequestModel model)
		{
			HttpContext.Session.Clear();
			if (ConstantMgr.isUseJwtAuth)
			{
				var res = _userJwtAuthenticator.Authenticate(model);
				logger.Info($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
				return Ok(res);
			}
			else
			{
				var res = _authenticator.Authenticate(model);
				HttpContext.SetUser(res.Data);
				logger.Info($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
				return Ok(res);
			}
		}
		[HttpPost]
		public IActionResult Register([FromBody] RegisterRequestModel model)
		{
			var res = _userService.Register(model);
			logger.Info($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
			return Ok(res);
		}
	}
}
