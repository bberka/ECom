namespace ECom.Domain.DTOs.UserDto;

public class UserLoginResponse
{
  public UserDto User { get; set; }
  public JwtToken Token { get; set; }
}