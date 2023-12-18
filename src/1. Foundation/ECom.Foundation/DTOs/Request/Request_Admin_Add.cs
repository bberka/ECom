namespace ECom.Foundation.DTOs.Request;

public class Request_Admin_Add : BaseAuthenticatedRequest
{
  [EmailAddress]
  [Required]
  [MaxLength(ConstantContainer.MaxEmailLength)]
  public string EmailAddress { get; set; }

  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string FirstName { get; set; }


  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string LastName { get; set; }

  [Required]
  [MaxLength(ConstantContainer.MaxPasswordLength)]
  [MinLength(ConstantContainer.MinPasswordLength)]
  public string Password { get; set; }

  [Required]
  [MinLength(ConstantContainer.MinNameLength)]
  [MaxLength(ConstantContainer.MaxNameLength)]
  public string RoleId { get; set; }

  [MinLength(ConstantContainer.MinPhoneLength)]
  [MaxLength(ConstantContainer.MaxPhoneLength)]
  public string PhoneNumber { get; set; }
}