





using EasMe.Authorization.Filters;
using EasMe.Logging;
using ECom.Application.Services;
using ECom.Domain.Constants;
using Ninject.Modules;
using ECom.Domain.DTOs.AdminDTOs;
using ECom.Domain.DTOs;

namespace ECom.WebApi.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/Admin/[controller]/[action]")]
    public class AuthController : Controller
    {
		private static readonly IEasLog logger = EasLogFactory.CreateLogger();
		private readonly IAdminService _adminService;
		private readonly IOptionService _optionService;
		private readonly IAdminJwtAuthenticator _adminJwtAuthenticator;
        private readonly ILogService _logService;

        public AuthController(
			IAdminService adminService,
			IOptionService optionService,
			IAdminJwtAuthenticator adminJwtAuthenticator,
            ILogService logService)
		{
			this._adminService = adminService;
			this._optionService = optionService;
			this._adminJwtAuthenticator = adminJwtAuthenticator;
            _logService = logService;
        }
		[HttpPost]
        public ActionResult<ResultData<AdminLoginResponse>> Login([FromBody] LoginRequest model)
        {
            var res = _adminJwtAuthenticator.Authenticate(model);
            var adminId = res.Data?.Admin.Id;
            _logService.AdminLog(res.ToResult(), adminId, "Auth.Login", model.EmailAddress, model.EncryptedPassword);
            return res.WithoutRv();
        }


	}
}
