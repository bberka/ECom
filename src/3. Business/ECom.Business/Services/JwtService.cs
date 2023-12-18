namespace ECom.Business.Services;

public static class JwtService
{
  public static EasJWT Jwt { get; set; } = new(EComAppSettings.This.JwtSecret,
                                               EComAppSettings.This.JwtIssuer,
                                               EComAppSettings.This.JwtAudience);
}