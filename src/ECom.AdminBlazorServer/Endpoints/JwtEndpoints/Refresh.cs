using Ardalis.ApiEndpoints;
using ECom.Application.Attributes;
using ECom.Domain.Abstract;
using ECom.Shared.DTOs.AdminDto;
using ECom.Shared.DTOs;
using ECom.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EasMe.Extensions;
using ECom.Domain;

namespace ECom.AdminBlazorServer.Endpoints.JwtEndpoints;

[EndpointRoute(typeof(Refresh))]
public class Refresh : EndpointBaseSync.WithRequest<RefreshTokenRequest>.WithResult<CustomResult<AdminLoginResponse>>
{
  private readonly IAdminJwtAuthenticator _adminJwtAuthenticator;

  public Refresh(IAdminJwtAuthenticator adminJwtAuthenticator) {
    _adminJwtAuthenticator = adminJwtAuthenticator;
  }
  [HttpPost]
  [AllowAnonymous]
  [EndpointSwaggerOperation(typeof(Refresh), "Creates JWT token")]
  public override CustomResult<AdminLoginResponse> Handle(RefreshTokenRequest request) {
    var result = _adminJwtAuthenticator.Refresh(request);
    if (!result.Status) return result;
    //Set cookie
    var token = result.Data!.Token;
    var cookieOptions = new CookieOptions {
      HttpOnly = true,
      Expires = token.ExpireUnix.UnixTimeStampToDateTime(),
      SameSite = SameSiteMode.Strict,
      Secure = true,
      Domain = JwtOption.This.Issuer,
      IsEssential = true,
    };
    HttpContext.Response.Cookies.Append(JwtOption.This.CookieName, token.Token, cookieOptions);
    return result;
  }


}