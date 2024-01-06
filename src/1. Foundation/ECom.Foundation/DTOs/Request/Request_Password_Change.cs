using ECom.Foundation.Static;

namespace ECom.Foundation.DTOs.Request;

public sealed class Request_Password_Change : BaseAuthenticatedRequest
{
  [Required]
  [DataType(DataType.Password)]
  public string OldPassword { get; set; } = null!;

  [DataType(DataType.Password)]
  [MaxLength(StaticValues.MAX_PASSWORD_LENGTH)]
  [MinLength(StaticValues.MIN_PASSWORD_LENGTH)]
  // [CanNotContain(Chars = " ")]
  // [AllowedChars(Chars = StaticValues.PasswordAllowedCharacters)]
  [Required]
  // [CanNotBeEqual(nameof(OldPassword))]
  public string NewPassword { get; set; } = null!;

  [Required]
  [DataType(DataType.Password)]
  [MaxLength(StaticValues.MAX_PASSWORD_LENGTH)]
  [MinLength(StaticValues.MIN_PASSWORD_LENGTH)]
  // [CanNotContain(Chars = " ")]
  // [AllowedChars(Chars = StaticValues.PasswordAllowedCharacters)]
  [Compare(nameof(NewPassword))]
  public string RepeatNewPassword { get; set; } = null!;
}