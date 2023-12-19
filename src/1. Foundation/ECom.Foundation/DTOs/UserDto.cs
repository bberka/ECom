using ECom.Foundation.Enum;

namespace ECom.Foundation.DTOs;

public class UserDto
{
  public Guid Id { get; set; }
  public string EmailAddress { get; set; } = null!;
  public DateTime RegisterDate { get; set; }
  public bool IsEmailVerified { get; set; }
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;
  public string PhoneNumber { get; set; } = null!;
  public TwoFactorType TwoFactorType { get; set; } = 0;
  public Language Culture { get; set; } = ConstantContainer.DefaultLanguage;
}