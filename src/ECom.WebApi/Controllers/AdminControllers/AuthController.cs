





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

		public AuthController(IAdminService adminService,IJwtOptionService jwtOptionService)
		{
			this._adminService = adminService;
			this._jwtOptionService = jwtOptionService;
		}
		[HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
#if DEBUG
			var jwt = new EasJWT(_jwtOptionService.GetFromCache().Secret);
            var adm = new Admin();
            var dic = adm.AsDictionary();
            dic.Add("AdminOnly","");
            var token = jwt.GenerateJwtToken(dic ,DateTime.Now.AddMinutes(10));
#endif

			HttpContext.Session.SetString("admin-token",token);
			return Ok();
			var res = AdminJwtAuthenticator.This.Authenticate(model);
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
