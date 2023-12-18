namespace ECom.Foundation.DTOs.Response;

public class Response_User_Login
{
  public UserDto User { get; set; } = null!;
  public JwtToken Token { get; set; } = null!;
}