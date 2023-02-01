using EasMe;
using EasMe.Extensions;
using ECom.Application.Manager;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{
    [ApiController]
    [Route("api/User/[controller]/[action]")]
    public class AuthController : Controller
    {
		private readonly static EasLog logger = EasLogFactory.CreateLogger(nameof(AuthController));

		[HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            try
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
			catch (Exception ex)
            {
				logger.Exception(ex,$"Login({model.ToJsonString()})");
                return StatusCode(500);
            }
        }
		[HttpPost]
		public IActionResult Register([FromBody] RegisterModel model)
		{
			try
			{
				var res = UserMgr.This.Register(model);
				if (!res.IsSuccess)
				{
					logger.Warn($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
					return BadRequest(res);
				}
				logger.Info($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
				return Ok(res);

			}
			catch (Exception ex)
			{
				logger.Exception(ex, $"Login({model.ToJsonString()})");
				return StatusCode(500);
			}
		}
	}
}
