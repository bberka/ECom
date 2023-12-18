﻿using ECom.Business.Attributes;
using ECom.Foundation.Abstract.Services.Admin;
using ECom.Foundation.DTOs.Response;
using ECom.Service.AdminApi.Abstract;

namespace ECom.Service.AdminApi.Controllers;

[AllowAnonymous]
public class AuthController : AdminControllerBase
{
  [FromServices]
  public IAdminJwtAuthenticator AdminJwtAuthenticator { get; set; }

  [Endpoint("/admin/auth/login", HttpMethodType.POST)]
  public Result<Response_Admin_Login> Login(Request_Login request) {
    var res = AdminJwtAuthenticator.Authenticate(request);
    var adminId = res.Data?.Admin.Id;
    LogService.AdminLog(AdminActionType.Login, res, adminId, request.EmailAddress);
    return res;
  }
}