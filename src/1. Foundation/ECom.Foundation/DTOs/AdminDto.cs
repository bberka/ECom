using ECom.Foundation.Static;

namespace ECom.Foundation.DTOs;

public class AdminDto
{
  public DateTime RegisterDate { get; set; }
  public Guid Id { get; set; }
  public string EmailAddress { get; set; }
  public TwoFactorType TwoFactorType { get; set; }
  public string RoleId { get; set; }

  public string[] Permissions { get; set; } = Array.Empty<string>();
  // public DateTime? DeleteDate { get; set; }

  public CultureType Culture { get; set; } = StaticValues.DEFAULT_LANGUAGE;


  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string FirstName { get; set; }


  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string LastName { get; set; }

  [MinLength(StaticValues.MIN_PHONE_LENGTH)]
  [MaxLength(StaticValues.MAX_PHONE_LENGTH)]
  public string PhoneNumber { get; set; }
}