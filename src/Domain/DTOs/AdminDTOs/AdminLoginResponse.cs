namespace ECom.Domain.DTOs.AdminDTOs;

public class AdminLoginResponse
{
  public AdminDto Admin { get; set; }
  public JwtToken Token { get; set; }
}