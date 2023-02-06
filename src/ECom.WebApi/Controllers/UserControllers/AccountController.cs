using ECom.Domain.ApiModels.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{
    public class AccountController : BaseUserController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }
        [HttpGet]
        public ActionResult<User> Get()
        {
            return HttpContext.GetUser();
        }
        [HttpPost]
        public ActionResult<Result> ChangePassword([FromBody] ChangePasswordRequestModel model)
        {
            return _userService.ChangePassword(model);
        }

    }
}
