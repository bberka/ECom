namespace ECom.Shared.DTOs.AdminDto;

public class AdminDto
{
  public DateTime RegisterDate { get; set; }
  public int Id { get; set; }
  public string EmailAddress { get; set; }
  public byte TwoFactorType { get; set; }
  public int RoleId { get; set; }
  public string RoleName { get; set; }
  public string[] Permissions { get; set; }
  public string Password { get; set; }
  public DateTime? DeletedDate { get; set; }
}