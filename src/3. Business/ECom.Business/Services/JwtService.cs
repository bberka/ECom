using ECom.Foundation.Static;

namespace ECom.Business.Services;

public static class JwtService
{
  public static EasJWT Jwt { get; set; } = new(DomAppSettings.This.JwtSecret,
                                               DomAppSettings.This.JwtIssuer,
                                               DomAppSettings.This.JwtAudience);
}