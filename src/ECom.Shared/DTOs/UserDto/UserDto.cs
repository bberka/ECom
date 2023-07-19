namespace ECom.Shared.DTOs.UserDto;

public class UserDto
{
  //public UserDto(User user)
  //{
  //    Culture = user.Culture;
  //    Id = user.Id;
  //    TwoFactorType = user.TwoFactorType;
  //    FirstName = user.FirstName;
  //    LastName = user.LastName;
  //    IsEmailVerified = user.IsEmailVerified;
  //    TaxNumber = user.TaxNumber;
  //    EmailAddress = user.EmailAddress;
  //    PhoneNumber = user.PhoneNumber;
  //}
  public int Id { get; set; }
  public string EmailAddress { get; set; } = null!;
  public bool IsEmailVerified { get; set; }
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;
  public string PhoneNumber { get; set; } = null!;
  public int? TaxNumber { get; set; }
  public byte TwoFactorType { get; set; } = 0;
  public string Culture { get; set; } = ConstantMgr.DefaultCulture;
}