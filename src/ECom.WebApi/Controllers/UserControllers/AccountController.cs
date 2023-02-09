using EasMe;
using ECom.Domain.ApiModels.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EasMe.Authorization;
using EasMe.Authorization.Filters;
using EasMe.Extensions;

namespace ECom.WebApi.Controllers.UserControllers
{
    public class AccountController : BaseUserController
    {
        private readonly IUserService _userService;
        private readonly ILogService _logService;

        public AccountController(
            IUserService userService,
            ILogService logService)
        {
            this._userService = userService;
            _logService = logService;
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
            var res = _userService.ChangePassword(model).WithoutRv();
            _logService.UserLog(res,model.AuthenticatedUserId,"Account.ChangePassword",model.EncryptedOldPassword,model.EncryptedNewPassword);
            return res;
        }

    }
}
