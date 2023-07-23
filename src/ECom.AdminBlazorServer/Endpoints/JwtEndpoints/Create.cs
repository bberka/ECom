using Ardalis.ApiEndpoints;
using EasMe.Extensions;
using ECom.Application.Attributes;
using ECom.Domain;
using ECom.Domain.Abstract;
using ECom.Shared;
using ECom.Shared.DTOs;
using ECom.Shared.DTOs.AdminDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.AdminBlazorServer.Endpoints.JwtEndpoints;

[EndpointRoute(typeof(Create))]
public class Create : EndpointBaseSync.WithRequest<LoginRequest>.WithResult<CustomResult<AdminLoginResponse>>
{
  private readonly IAdminJwtAuthenticator _adminJwtAuthenticator;

  public Create(IAdminJwtAuthenticator adminJwtAuthenticator) {
    _adminJwtAuthenticator = adminJwtAuthenticator;
  }

  [HttpPost]
  [AllowAnonymous]
  [EndpointSwaggerOperation(typeof(Create), "Creates JWT token")]
  public override CustomResult<AdminLoginResponse> Handle(LoginRequest request) {
    var result = _adminJwtAuthenticator.Authenticate(request);
    if (!result.Status) return result;
    //Set cookie
    var token = result.Data!.Token;
    var cookieOptions = new CookieOptions {
      HttpOnly = true,
      Expires = token.ExpireUnix.UnixTimeStampToDateTime(),
      SameSite = SameSiteMode.Strict,
      Secure = true,
      Domain = JwtOption.This.Issuer,
      IsEssential = true
    };
    HttpContext.Response.Cookies.Append(JwtOption.This.CookieName, token.Token, cookieOptions);
    return result;
  }
}