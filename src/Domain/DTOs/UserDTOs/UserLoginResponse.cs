namespace ECom.Domain.DTOs.UserDTOs;

public class UserLoginResponse
{
  public UserDto User { get; set; }
  public JwtToken Token { get; set; }
}