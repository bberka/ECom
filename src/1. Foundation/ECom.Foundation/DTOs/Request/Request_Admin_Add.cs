using ECom.Foundation.Static;

namespace ECom.Foundation.DTOs.Request;

public class Request_Admin_Add : BaseAuthenticatedRequest
{
  [EmailAddress]
  [Required]
  [MaxLength(StaticValues.MAX_EMAIL_LENGTH)]
  public string EmailAddress { get; set; }

  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string FirstName { get; set; }


  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string LastName { get; set; }

  [Required]
  [MaxLength(StaticValues.MAX_PASSWORD_LENGTH)]
  [MinLength(StaticValues.MIN_PASSWORD_LENGTH)]
  public string Password { get; set; }

  [Required]
  [MinLength(StaticValues.MIN_NAME_LENGTH)]
  [MaxLength(StaticValues.MAX_NAME_LENGTH)]
  public string RoleId { get; set; }

  [MinLength(StaticValues.MIN_PHONE_LENGTH)]
  [MaxLength(StaticValues.MAX_PHONE_LENGTH)]
  public string PhoneNumber { get; set; }
}