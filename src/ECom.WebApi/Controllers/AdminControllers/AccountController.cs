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
        public ActionResult<Admin> Get()
        {
            return HttpContext.GetAdmin();
        }
        
        [HttpPost]
        public ActionResult<Result> ChangePassword(ChangePasswordRequestModel model)
        {
            return _adminService.ChangePassword(model);
        }
        //[HttpPost]
        //public IActionResult Update(UpdateAdminAccountRequestModel model)
        //{
        //    var admin = HttpContext.GetAdmin();
        //    return Ok(admin);
        //}

    }
}
