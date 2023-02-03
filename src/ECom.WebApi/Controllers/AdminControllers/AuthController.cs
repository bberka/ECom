﻿





using ECom.Application.Services;
using ECom.Infrastructure.Interfaces;

namespace ECom.WebApi.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/Admin/[controller]/[action]")]
    public class AuthController : Controller
    {
		private readonly static EasLog logger = EasLogFactory.CreateLogger(nameof(AuthController));
		private readonly IAdminService _adminService;
		private readonly IOptionService _optionService;
		private readonly IAdminJwtAuthenticator _adminJwtAuthenticator;
		private readonly IAuthenticator<Admin> _authenticator;

		public AuthController(
			IAdminService adminService,
			IOptionService optionService,
			IAdminJwtAuthenticator adminJwtAuthenticator,
			IAuthenticator<Admin> authenticator)
		{
			this._adminService = adminService;
			this._optionService = optionService;
			this._adminJwtAuthenticator = adminJwtAuthenticator;
			this._authenticator = authenticator;
		}
		[HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
			HttpContext.Session.Clear();
			if (ConstantMgr.isUseJwtAuth)
			{
				var res = _adminJwtAuthenticator.Authenticate(model);
				if (!res.IsSuccess)
				{
					logger.Warn($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
					return BadRequest(res);
				}
				logger.Info($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
				return Ok(res);
			}
			else
			{
				var res = _authenticator.Authenticate(model);
				if (!res.IsSuccess)
				{
					logger.Warn($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
					return BadRequest(res);
				}
				HttpContext.SetAdmin(res.Data);
				logger.Info($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
				return Ok(res);
			}
        }

		[HttpPost]
		public IActionResult Add([FromBody] AdminAddModel model)
		{
#if !DEBUG
            return NotFound();
#endif
			var res = _adminService.AddAdmin(model);
			return Ok(res);
		}

	}
}
