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

		public AuthController(
			IUserService userService,
			IUserJwtAuthenticator userJwtAuthenticator)
		{
			this._userService = userService;
			this._userJwtAuthenticator = userJwtAuthenticator;
		}
		[HttpPost]
		public IActionResult Login([FromBody] LoginRequestModel model)
		{
			HttpContext.Session.Clear();
            var res = _userJwtAuthenticator.Authenticate(model);
            logger.Info($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
            return Ok(res);
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
