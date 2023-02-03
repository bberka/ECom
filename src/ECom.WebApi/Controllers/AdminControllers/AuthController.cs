





using ECom.Application.Services;

namespace ECom.WebApi.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/Admin/[controller]/[action]")]
    public class AuthController : Controller
    {
		private readonly static EasLog logger = EasLogFactory.CreateLogger(nameof(AuthController));
		private readonly IAdminService _adminService;
		private readonly IJwtOptionService _jwtOptionService;
		private readonly IAdminJwtAuthenticator _adminJwtAuthenticator;

		public AuthController(
			IAdminService adminService,
			IJwtOptionService jwtOptionService,
			IAdminJwtAuthenticator adminJwtAuthenticator)
		{
			this._adminService = adminService;
			this._jwtOptionService = jwtOptionService;
			this._adminJwtAuthenticator = adminJwtAuthenticator;
		}
		[HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
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

		[HttpPost]
		private IActionResult AddNewAdmin([FromBody] Admin model)
		{
#if !DEBUG
            return NotFound();
#endif
			var res = _adminService.Add(model);
			return Ok(res);
		}

	}
}
