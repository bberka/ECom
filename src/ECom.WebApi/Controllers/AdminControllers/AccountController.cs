using EasMe.Authorization.Filters;
using ECom.Domain.DTOs.Request;
using ECom.Domain.Constants;
using ECom.Domain.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        public ActionResult<AdminDto> Get()
        {
            var admin = HttpContext.GetAdmin();
            return admin;
            //var res = _adminService.GetAdmin(adminId).WithoutRv();
            //_logService.AdminLog(res.ToResult(),adminId,"Account.Get");
            //return res;
        }

        
        [HttpPost]
        public ActionResult<Result> ChangePassword(ChangePasswordRequest model)
        {
            var res = _adminService.ChangePassword(model).WithoutRv();
            _logService.AdminLog(res, model.AuthenticatedAdminId, "Account.ChangePassword",model.EncryptedOldPassword,model.EncryptedNewPassword);
            return res;
        }


    }
}
