﻿using EasMe;
using ECom.Domain.ApiModels.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EasMe.Authorization;
using EasMe.Authorization.Filters;
using EasMe.Extensions;
using ECom.Domain.Models;

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
        public ActionResult<UserNecessaryInfo> Get()
        {
            var user = HttpContext.GetUser();
            return user;
        }
        [HttpPost]
        public ActionResult<Result> ChangePassword([FromBody] ChangePasswordRequestModel model)
        {
            var res = _userService.ChangePassword(model).WithoutRv();
            _logService.UserLog(res,model.AuthenticatedUserId,"Account.ChangePassword",model.EncryptedOldPassword,model.EncryptedNewPassword);
            return res.WithoutRv();
        }

        [HttpPost]
        public ActionResult<Result> Update([FromBody] UpdateUserRequestModel model)
        {
            var userId = model.AuthenticatedUserId;
            var res = _userService.Update(model);
            _logService.UserLog(res,userId,"Account.Update",model.ToJsonString());
            return res.WithoutRv();
        }
    }
}
