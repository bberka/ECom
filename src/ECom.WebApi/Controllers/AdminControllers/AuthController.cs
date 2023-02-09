





using EasMe.Authorization.Filters;
using EasMe.Logging;
using ECom.Application.Services;
using ECom.Domain.ApiModels.Request;
using ECom.Domain.ApiModels.Response;
using ECom.Domain.Constants;
using ECom.Domain.Interfaces;
using Ninject.Modules;

namespace ECom.WebApi.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/Admin/[controller]/[action]")]
    public class AuthController : Controller
    {
		private static readonly EasLog logger = EasLogFactory.CreateLogger(nameof(AuthController));
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
        public ActionResult<ResultData<AdminLoginResponseModel>> Login([FromBody] LoginRequestModel model)
        {
			HttpContext.Session.Clear();
            var res = _adminJwtAuthenticator.Authenticate(model);
            _logService.AdminLog(res.ToResult(),-1,"Auth.Login",model.EmailAddress,model.EncryptedPassword);
            return res.WithoutRv();
           
        }


	}
}
