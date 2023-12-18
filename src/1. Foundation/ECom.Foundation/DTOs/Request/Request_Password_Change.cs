namespace ECom.Foundation.DTOs.Request;

public sealed class Request_Password_Change : BaseAuthenticatedRequest
{
  [Required]
  [DataType(DataType.Password)]
  public string OldPassword { get; set; } = null!;

  [DataType(DataType.Password)]
  [MaxLength(ConstantContainer.MaxPasswordLength)]
  [MinLength(ConstantContainer.MinPasswordLength)]
  // [CanNotContain(Chars = " ")]
  // [AllowedChars(Chars = ConstantContainer.PasswordAllowedCharacters)]
  [Required]
  // [CanNotBeEqual(nameof(OldPassword))]
  public string NewPassword { get; set; } = null!;

  [Required]
  [DataType(DataType.Password)]
  [MaxLength(ConstantContainer.MaxPasswordLength)]
  [MinLength(ConstantContainer.MinPasswordLength)]
  // [CanNotContain(Chars = " ")]
  // [AllowedChars(Chars = ConstantContainer.PasswordAllowedCharacters)]
  [Compare(nameof(NewPassword))]
  public string RepeatNewPassword { get; set; } = null!;
}