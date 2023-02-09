using EasMe.Authorization.Filters;
using ECom.Domain.ApiModels.Request;
using ECom.Domain.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{
    public class AccountController : BaseAdminController
    {
        private readonly IAdminService _adminService;
        private readonly ILogService _logService;

        public AccountController(
            IAdminService adminService,
            ILogService logService)
        {
            this._adminService = adminService;
            _logService = logService;
        }
        [HttpGet]
        public ActionResult<ResultData<Admin>> Get()
        {
            var adminId = HttpContext.GetAdminId();
            var res = _adminService.GetAdmin(adminId).WithoutRv();
            _logService.AdminLog(res.ToResult(),adminId,"Account.Get");
            return res;
        }

        
        [HttpPost]
        public ActionResult<Result> ChangePassword(ChangePasswordRequestModel model)
        {
            var res = _adminService.ChangePassword(model).WithoutRv();
            _logService.AdminLog(res, model.AuthenticatedAdminId, "Account.ChangePassword",model.EncryptedOldPassword,model.EncryptedNewPassword);
            return res;
        }


    }
}
