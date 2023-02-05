using ECom.Domain.ApiModels.Request;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{
    public class AccountController : BaseAdminController
    {
        [HttpGet]
        public IActionResult Get()
        {
            var admin = HttpContext.GetAdmin();
            return Ok(admin);
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordRequestModel model)
        {
            var admin = HttpContext.GetAdmin();
            return Ok(admin);
        }
        [HttpPost]
        public IActionResult Update(UpdateAdminAccountRequestModel model)
        {
            var admin = HttpContext.GetAdmin();
            return Ok(admin);
        }

    }
}
