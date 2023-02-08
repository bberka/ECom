using ECom.Domain.ApiModels.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EasMe.Authorization;
using EasMe.Authorization.Filters;
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
            var user = HttpContext.GetUser();
            return user;
        }
        [HttpPost]
        public ActionResult<Result> ChangePassword([FromBody] ChangePasswordRequestModel model)
        {
            return _userService.ChangePassword(model).WithoutRv();
        }

    }
}
