namespace ECom.Shared.DTOs;

public class UserLoginResponse
{
    public UserDto User { get; set; } = null!;
    public JwtToken Token { get; set; } = null!;
}