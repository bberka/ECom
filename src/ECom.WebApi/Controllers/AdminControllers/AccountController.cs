using ECom.Domain.ApiModels.Request;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{
    public class AccountController : BaseAdminController
    {
        private readonly IAdminService _adminService;

        public AccountController(IAdminService adminService)
        {
            this._adminService = adminService;
        }
        [HttpGet]
        public ActionResult<ResultData<Admin>> Get()
        {
            var adminId = HttpContext.GetAdminId();
            return _adminService.GetAdmin(adminId);
        }
        
        [HttpPost]
        public ActionResult<Result> ChangePassword(ChangePasswordRequestModel model)
        {
            return _adminService.ChangePassword(model);
        }


    }
}
