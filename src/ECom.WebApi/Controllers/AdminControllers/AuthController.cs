﻿





using EasMe.Authorization.Filters;
using EasMe.Logging;
using ECom.Application.Services;
using ECom.Domain.ApiModels.Request;
using ECom.Domain.ApiModels.Response;
using ECom.Domain.Constants;
using ECom.Domain.Interfaces;
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

		public AuthController(
			IAdminService adminService,
			IOptionService optionService,
			IAdminJwtAuthenticator adminJwtAuthenticator)
		{
			this._adminService = adminService;
			this._optionService = optionService;
			this._adminJwtAuthenticator = adminJwtAuthenticator;
		}
		[HttpPost]
        public ActionResult<ResultData<AdminLoginResponseModel>> Login([FromBody] LoginRequestModel model)
        {
			HttpContext.Session.Clear();
            var res = _adminJwtAuthenticator.Authenticate(model);
            logger.Info($"Login({model.ToJsonString()}) Result({res.ToJsonString()})");
            return res;
           
        }

		[HttpPost]
        [EndPointAuthorizationFilter(AdminOperationType.Admin_Add)]
        public ActionResult<Result> Add([FromBody] AddAdminRequestModel model)
		{
#if !DEBUG
            return NotFound();
#endif
			var res = _adminService.AddAdmin(model);

			return res;
		}

	}
}
