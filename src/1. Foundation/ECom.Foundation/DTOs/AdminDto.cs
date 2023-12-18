using ECom.Foundation.Enum;

namespace ECom.Foundation.DTOs;

public class AdminDto
{
  public DateTime RegisterDate { get; set; }
  public Guid Id { get; set; }
  public string EmailAddress { get; set; }
  public TwoFactorType TwoFactorType { get; set; }
  public string RoleId { get; set; }
  public string[] Permissions { get; set; } = Array.Empty<string>();
  public DateTime? DeleteDate { get; set; }

  public LanguageType Culture { get; set; } = ConstantContainer.DefaultLanguage;


  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string FirstName { get; set; }


  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string LastName { get; set; }

  [MinLength(ConstantContainer.MinPhoneLength)]
  [MaxLength(ConstantContainer.MaxPhoneLength)]
  public string PhoneNumber { get; set; }
}