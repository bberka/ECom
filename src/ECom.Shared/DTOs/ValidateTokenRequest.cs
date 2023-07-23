namespace ECom.Shared.DTOs;

public class ValidateTokenRequest
{
  /// <summary>
  /// Jwt token to be validated by the server
  /// </summary>
  public string Token { get; set; }
}