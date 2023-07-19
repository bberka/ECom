namespace ECom.Shared.DTOs.UserDto;

public class UserLoginResponse
{
  public UserDto User { get; set; } = null!;
  public JwtToken Token { get; set; } = null!;
}